import clr
clr.AddReference('SharpDX.Mathematics')
from SharpDX import *

class ObjectWrapper():
  def __init__(self, name, geometry, material, transform):
    self.Name = name
    self.Geometry = geometry
    self.Material = material
    self.Transform = transform