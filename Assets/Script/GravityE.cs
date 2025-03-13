using System;
using System.Collections.Generic;
using UnityEngine;

public class GravityE : MonoBehaviour
{
   private Rigidbody rb;
   const float G = 0.00674f;

   public static List<GravityE> gravityObjectList;

   [SerializeField] bool planet = false;
   [SerializeField] private int orbitSpeed = 1000;
   
   private void Awake()
   {
      rb = GetComponent<Rigidbody>();
      if (gravityObjectList == null)
      {
         gravityObjectList = new List<GravityE>();
      }
      gravityObjectList.Add(this);

      if (!planet)
      {rb.AddForce(Vector3.left * orbitSpeed); }
      
   }

   private void FixedUpdate()
   {
      foreach (var obj in gravityObjectList)
      {
         if (obj != null)
         {
            Attract(obj);
         }
      }
   }


   void Attract(GravityE other)
   {
      Rigidbody otherRb = other.rb;
      
      Vector3 direction = rb.position - otherRb.position;
      float distance = direction.magnitude;
      float forceMagnitude = G * ((rb.mass * otherRb.mass) /Mathf.Pow(distance,2));
      Vector3 finalForce = forceMagnitude * direction.normalized;
      
      otherRb.AddForce(finalForce);
   }
   
   
   
   
}
