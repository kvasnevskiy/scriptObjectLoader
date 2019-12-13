# -*- coding: utf-8 -*-

import clr
clr.AddReferenceToFileAndPath('SharpDX.Mathematics')
from SharpDX import *

class ObjectWrapper():
  def __init__(self, geometry, material, transform):
    self.Geometry = geometry
    self.Material = material
    self.Transform = transform

def GetObjectRepresentation():
    mesh = GeometryManager.CreateSphere(Vector3(0,0,0), 0.5)
    material = MaterialManager.GetMaterial(11)

    return ObjectWrapper(mesh, material, 0)