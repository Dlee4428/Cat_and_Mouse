using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boids : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] DataFloat desiredSeparation;
    [SerializeField] DataFloat neibourDistance;
    [SerializeField] DataFloat maxForce;
    [SerializeField] DataFloat maxSpeed;
    [SerializeField] DataVector3 velocity;
    [SerializeField] DataVector3 acceleration;
    [Header("References")]
    [SerializeField] private Data data;
    [SerializeField] public Flock flock;

    // Start is called before the first frame update
    void Start()
    {
        desiredSeparation = data.Float(desiredSeparation);
        neibourDistance = data.Float(neibourDistance);
        maxForce = data.Float(maxForce);
        maxSpeed = data.Float(maxSpeed);
        velocity = data.Vector3(velocity);
        acceleration = data.Vector3(acceleration);

        float angle = Random.Range(0, Mathf.PI * 2);
        velocity.Value = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle));
        acceleration.Value = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 separate = Separate(flock.GetBoidList());
        Vector3 alignment = Align(flock.GetBoidList());
        Vector3 cohesion = Cohesion(flock.GetBoidList());

        acceleration.Value = Vector3.zero;
        acceleration.Value += separate * 1.5f;
        acceleration.Value += alignment;
        acceleration.Value += cohesion;

        Vector3 avoid = AvoidObstacles(flock.GetObstacleList());
        acceleration.Value += avoid;

        float dt = Time.deltaTime;
        dt *= 5;

        Vector3 pos = this.transform.position;
        pos += velocity.Value * dt + 0.5f * velocity.Value * dt * dt;
        velocity.Value += acceleration.Value * dt;
        acceleration.Value = Vector3.zero;

        if (pos.x > 15) pos.x = -15;
        if (pos.x < -15) pos.x = 15;
        if (pos.y > 15) pos.y = -15;
        if (pos.y < -15) pos.y = 15;
        this.transform.position = pos;

        Debug.Log(pos);

        float angle = Mathf.Acos(Vector3.Dot(velocity.Value.normalized, Vector3.up));

        transform.eulerAngles = new Vector3(0, 0, Mathf.Rad2Deg * angle * (velocity.Value.x > 0 ? -1 : 1));
    }

    Vector3 Separate(List<GameObject> boids)
    {
        Vector3 steer = Vector3.zero;
        int counter = 0;

        foreach (GameObject other in boids)
        {
            if (other == gameObject) continue;
            float d = Vector3.Distance(this.transform.position, other.transform.position);

            if((d > 0) && (d < (float)desiredSeparation)){
                Vector3 diff = this.transform.position - other.transform.position;
                diff.Normalize();
                diff /= d;
                steer += diff;
                counter++;
            }
        }

        if(counter > 0)
        {
            steer /= counter;
        }

        if(steer.magnitude > 0)
        {
            steer.Normalize();
            steer *= (float)maxSpeed;
            steer -= velocity.Value;
            if (steer.magnitude > (float)maxForce)
            {
                steer.Normalize();
                steer *= (float)maxForce;
            }
        }
        return steer;
    }

    Vector3 Align(List<GameObject> boids)
    {
        // For every nearby boid in the system, calculate the average velocity
        Vector3 sum = Vector3.zero;
        Vector3 steer = Vector3.zero;
        int counter = 0;

        foreach (GameObject other in boids)
        {
            if (other == gameObject) continue;

            float d = Vector3.Distance(this.transform.position, other.transform.position);
            if ((d > 0) && (d < (float)neibourDistance))
            {
                sum += other.GetComponent<Boids>().velocity.Value;
                counter++;
            }
        }

        if (counter > 0)
        {
            sum /= counter;
            sum.Normalize();
            sum *= (float)maxSpeed;
            steer = sum - velocity.Value;
            if (steer.magnitude < (float)maxForce)
            {
                steer.Normalize();
                steer *= (float)maxForce;
            }
            return steer;
        }
        else
        {
            return Vector3.zero;
        }
    }

    Vector3 Cohesion(List<GameObject> boids)
    {
        // For the average position (i.e. center) of all nearby boids, calculate steering vector towards that position
        Vector3 sum = Vector3.zero;
        int counter = 0;

        foreach (GameObject other in boids)
        {
            if (other == gameObject) continue;

            float d = Vector3.Distance(transform.position, other.transform.position);
            if ((d > 0) && (d < (float)neibourDistance))
            {
                // To do : Calculate the sum of all the positions of the boids    
                sum += other.transform.position;
                counter++;
            }
        }

        if (counter > 0)
        {
            Vector3 averagePos = Vector3.zero;
            sum /= counter;
            return SeekTarget(sum);
        }

        return Vector3.zero;
    }

    Vector3 SeekTarget(Vector3 target)
    {
        Vector3 desired = target - transform.position;
        desired.Normalize();
        desired /= (float)maxSpeed;

        Vector3 steer = desired - velocity.Value;
        if (steer.magnitude > (float)maxForce)
        {
            steer.Normalize();
            steer *= (float)maxForce;
        }

        return steer;
    }

    Vector3 AvoidObstacles(List<GameObject> obstacles)
    {
        Vector3 steer = Vector3.zero;
        float collision_visibilty = 20;
        float obstacle_radius = 5;

        foreach (GameObject obstacle in obstacles)
        {
            Vector3 a = obstacle.transform.position - transform.position;
            Vector3 u = velocity.Value.normalized;
            Vector3 v = u * collision_visibilty;
            Vector3 p = Vector3.Dot(a, u) * u;
            Vector3 b = p - a;

            if ((b.magnitude < obstacle_radius) && (p.magnitude < v.magnitude))
            {
                Vector3 n = new Vector3(a.y, -a.x, 0);
                Vector3 desired = Vector3.zero;
                float dir = Vector3.Dot(n, v);
                steer = n.normalized * (float)maxSpeed * dir / Mathf.Abs(dir);
                if (steer.magnitude > (float)maxForce)
                {
                    steer.Normalize();
                    steer *= (float)maxForce;
                }
            }
        }
        return steer;
    }
}
