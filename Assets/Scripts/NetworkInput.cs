using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using System;

public struct NetworkInput : INetworkInput
{
    public Vector2 movementInput;
    public Vector3 aimForwardVector;
    public NetworkBool isJumpPressed;

}
