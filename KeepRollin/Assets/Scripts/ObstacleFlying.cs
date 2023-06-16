using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ObstacleFlying : MonoBehaviour
{
    public float speed;

    public Vector3 minScale;
    public Vector3 maxScale;
    public float scaleSpeed = 2f;
    public float scaleDuration = 5f;

    //Start is called before the first frame update

    private void Awake()
    {
        
    }

    IEnumerator Start()
    {
        minScale = transform.localScale;
        yield return ScaleUp(minScale, maxScale, scaleDuration);
        yield return new WaitForSeconds(100020f);
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.up * speed * Time.deltaTime);
        
    }

    public IEnumerator ScaleUp(Vector3 min, Vector3 max, float time)
    {
        float i = 0.0f;
        float rate = (1.0f / time) * scaleSpeed;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(min, max, i);
            yield return null;
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
