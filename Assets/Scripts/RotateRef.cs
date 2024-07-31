using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRef : MonoBehaviour
{
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.Find("AudioManager").GetComponent<AudioSource>();
    }

    void Update()
    {
        // Code for OnMouseDown in the iPhone. Unquote to test.
        /*   RaycastHit hit = new RaycastHit();
          for (int i = 0; i < Input.touchCount; ++i)
          {
              if (Input.GetTouch(i).phase.Equals(TouchPhase.Began))
              {
                  // Construct a ray from the current touch coordinates
                  Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                  if (Physics.Raycast(ray, out hit))
                  {
                      if (hit.transform.gameObject == gameObject)
                      {
                          RotateR();
                      }

                    //  hit.transform.gameObject.SendMessage("OnMouseDown");
                  }
              }
          }*/
        if (Input.GetMouseButtonDown(0))
          {
              Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
              RaycastHit hit2;
              if (Physics.Raycast(ray, out hit2))
              {
                  if (hit2.transform.gameObject == gameObject) {
                      RotateR();
                  }
              }
          }
    }

    public void RotateR() {
        audioSource.Play();
        Vector3 customRotation = new Vector3(0f, 0.25f, 0f);
        iTween.RotateBy(gameObject, customRotation, 0.5f);
    }
}
