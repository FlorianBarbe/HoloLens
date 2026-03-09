using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject gamo;

    


    void Start()
    {
        Collider col = gamo.GetComponent<Collider>();
    }


    // Update is called once per frame
    void Update()
    {
        //OnTriggerEnter(col);
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
    }

}