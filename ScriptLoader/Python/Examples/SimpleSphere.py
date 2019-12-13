# -*- coding: utf-8 -*-

import clr
clr.AddReference('SharpDX.Mathematics')
from SharpDX import *


def GetObjectRepresentation():
    mesh = GeometryManager.CreateSphere(Vector3(0.0, 0.0, 0.0), 1.0)
    material = MaterialManager.GetMaterial(12)

    return ObjectWrapper('sphere', mesh, material, 0)