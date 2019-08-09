using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AvatarPlacement : MonoBehaviour
{
    public Terrain terrain;
    public Transform avatar;
    public Transform camera;
    public double initialAngle;
    public double finalAngle;
    public int Distance;

    /*
     * Parameters
     *  distance: how far the avatar will be placed from the camera
     * 
     */ 
    public Vector3 placeAvatar(float distance) {
        float cameraX = camera.position.x;
        float cameraZ = camera.position.z;
        float cameraAngleY = camera.eulerAngles.y;

        double minAngle = (cameraAngleY + initialAngle) * Math.PI / 180;
        double maxAngle = (cameraAngleY + finalAngle) * Math.PI / 180;

        double randomAngle = GetRandomNumber(minAngle, maxAngle);

        double avatarX = cameraX + distance * Math.Sin(randomAngle);
        double avatarZ = cameraZ + distance * Math.Cos(randomAngle);

        Vector3 findTerrainHeight = new Vector3((float) avatarX, 0.0f, (float) avatarZ);

        float avatarY = terrain.SampleHeight(findTerrainHeight);

        avatar.position = new Vector3((float) avatarX, avatarY, (float) avatarZ);

        //Returns the distance of the avatar to the camera
        Debug.Log(Math.Sqrt(Math.Pow(avatarX - cameraX,2) + Math.Pow(avatarZ - cameraZ,2)));

        return avatar.position;
    }

    public double GetRandomNumber(double minimum, double maximum)
    {
        System.Random random = new System.Random();
        return random.NextDouble() * (maximum - minimum) + minimum;
    }

    void Start()
    {
        Vector3 vect = placeAvatar(Distance);
    }
}
