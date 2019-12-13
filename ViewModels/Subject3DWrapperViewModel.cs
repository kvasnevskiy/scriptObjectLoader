using BasicObjectsLibrary.Models.Subjects;

namespace ScriptObjectLoader.ViewModels
{
    public class Subject3DWrapperViewModel : Subject3DViewModel
    {
        public string Name => Model.Name;

        public new Subject3DWrapperModel Model
        {
            get => base.Model as Subject3DWrapperModel;
            set => base.Model = value;
        }

        public Subject3DWrapperViewModel(Subject3DWrapperModel model) : base(model)
        {
        }
    }
}
