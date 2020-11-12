using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsManager : MonoBehaviour
{
    private Sucker[] suckers;

    void Start()
    {
        metalObjects = FindObjectsOfType<MetalObject>();
        suckers = FindObjectsOfType<Sucker>();
        for (int i = 0; i < suckers.Length; i++)
        {
            suckers[i].Initialise();
        }
        InitailaiseMetalObjects();

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void ManageSuckers()
    {
        for (int j = 0; j < suckers.Length; j++)
        {
            //bool isMagneto = /*metalObjectsToAttractMagneto &&*/( magnets[j] == magneto);
            Attraction attraction = suckers[j].attractionField;
            Vector3 attractionPoint = attraction.attractopnPoint.position;
            Bounds bounds = new Bounds
                (attractionPoint, Vector3.one * attraction.radius * boundsExpansion);
            float magnetAttractionDistance = magnetAttraction.radius;

            // Vector3 magnetPosition = magnets[j].attrractivePoint.position;
            for (int i = 0; i < metalObjects.Length; i++)
            {
                MetalObject metalObject = metalObjects[i];
                if (metalObject.attatched || (metalObject.Tier > magnetoLevel && metalObject.attractionForce == 0))
                {
                    continue;
                }
                //if (!metalObject.IsAttachedTo(magnets[j]))
                {
                    Transform metalObjectTransform = metalObject.transform;
                    Vector3 metalObjectPosition = metalObjectTransform.position;
                    if (!bounds.Contains(metalObjectPosition))
                    {
                        continue;
                    }
                    float distanceFromMagnet =
                        Vector3.Distance(attractionPoint, metalObjectPosition);
                    if (distanceFromMagnet <= magnetAttractionDistance)
                    {
                        // Debug.Log("distanceFromMagnet" + distanceFromMagnet);
                        float attractionSpeed =
                           (Mathf.Abs(distanceFromMagnet - magnetAttractionDistance) / magnetAttractionDistance)
                           * magnetAttraction.force;
                        #region old but might come back:
                        /*if (metalObject.IsAttachedToSomeMagnet())
                        {
                            if(attractionSpeed> metalObject.attraction)
                            {
                                metalObject.Detach();
                            }
                            else
                            {
                                continue;
                            }
                        }*/

                        // bool attract = true;
                        if ( /* isMagneto  &&*/  metalObject.attractionForce != 0)
                        {
                            Debug.Log(" metalObject.attractionForce != 0");
                            /*if( false && magnetoLevel < metalObject.Tier)
                            {*/
                            //if (metalObjectsToAttractMagneto )
                            // {
                            magneto.AddForce
                            ((metalObjectPosition - attractionPoint).normalized
                            * (metalObject.attractionForce), ForceMode.Force);
                            /* deltaTime), ForceMode.Force);
                        }
                    }
                    else *//*if (magnetoLevel > metalObject.Tier)
                    {
                        if(distanceFromMagnet < magnetAttraction.radius / permenantAttachmentRadiusDevider)
                        {
                            AttatchPermenantly(metalObject,magneto);
                            attract = false;
                        }
                    }*/
                        }

                        // if (attract)
                        #endregion
                    }
                }
            }
        }
    }
}
