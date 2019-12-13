# -*- coding: utf-8 -*-

import clr
clr.AddReference('SharpDX.Mathematics')
from SharpDX import *


def GetObjectRepresentation():
    mesh = GeometryManager.CreateBox(Vector3(0.0, 0.0, 0.0), 1.0, 1.0, 1.0)
    material = MaterialManager.GetMaterial(11)

    return ObjectWrapper('box', mesh, material, 0)