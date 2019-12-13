using BasicObjectsLibrary.Models.Subjects;
using Prism.Mvvm;

namespace ScriptObjectLoader.ViewModels
{
    public class Subject3DViewModel : BindableBase
    {
        public Subject3DModel Model { get; set; }

        public Subject3DViewModel(Subject3DModel model)
        {
            Model = model;
        }
    }
}
