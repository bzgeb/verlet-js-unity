﻿using System.Linq;
using UnityEngine;

public class SandboxController : MonoBehaviour
{
    [SerializeField] PixelScreen pScreen;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            //pScreen.LowResActive = !pScreen.LowResActive;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CompositeCreator.CreateBox(GrabHandler.Instance.MouseGamePos);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CompositeCreator.CreateRope(GrabHandler.Instance.MouseGamePos);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Composite rope = CompositeCreator.CreateRope(GrabHandler.Instance.MouseGamePos);
            Particle lastRopeSegment = rope.particles.Last();

            Composite box = CompositeCreator.CreateBox(lastRopeSegment.pos, false);
            box.constraints.Add(new DistanceConstraint(box.particles[0], lastRopeSegment, 0.25f));
            VerletHandler.Instance.RebuildBody(box);
        }
    }
}