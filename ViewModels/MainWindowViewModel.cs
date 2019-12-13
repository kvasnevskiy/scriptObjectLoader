using System.Collections.ObjectModel;
using HelixToolkit.Wpf.SharpDX;
using Prism.Commands;
using Prism.Mvvm;
using SharpDX;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using ScriptObjectLoader.ScriptLoader;
using Camera = HelixToolkit.Wpf.SharpDX.Camera;
using Color = System.Windows.Media.Color;
using PerspectiveCamera = HelixToolkit.Wpf.SharpDX.PerspectiveCamera;

namespace ScriptObjectLoader.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        #region Script Loader

        protected IScriptLoader ScriptLoader { get; set; }

        #endregion

        #region Effects Manager

        private IEffectsManager effectsManager;
        public IEffectsManager EffectsManager
        {
            get => effectsManager;
            protected set => SetProperty(ref effectsManager, value);
        }

        #endregion

        #region Camera

        private Camera camera;
        public Camera Camera
        {
            get => camera;
            protected set => SetProperty(ref camera, value);
        }

        public Vector3D UpDirection { set; get; } = new Vector3D(0, 0, 1);

        #endregion

        #region Lights

        public Color DirectionalLightColor { get; private set; }
        public Color AmbientLightColor { get; private set; }

        #endregion

        #region Grid

        public LineGeometry3D Grid { get; private set; }
        public Color GridColor { get; private set; }
        public Transform3D GridTransform { get; private set; }

        #endregion

        #region Model Collection

        public ObservableCollection<Subject3DViewModel> Items { get; } = new ObservableCollection<Subject3DViewModel>();

        protected void AddModel(Subject3DViewModel viewModel) => Items.Add(viewModel);

        protected void ClearModels() => Items.Clear();

        #endregion

        #region Commands

        public DelegateCommand LoadCommand => new DelegateCommand(() =>
        {
           var dlg = new Microsoft.Win32.OpenFileDialog();

            if (dlg.ShowDialog() == true)
            {
                var loadModel = ScriptLoader.Load(dlg.FileName);
                ClearModels();
                AddModel(new Subject3DWrapperViewModel(loadModel));
            }
        });

        #endregion

        #region Constructors

        public MainWindowViewModel(IScriptLoader scriptLoader)
        {
            ScriptLoader = scriptLoader;

            EffectsManager = new DefaultEffectsManager();

            Camera = new PerspectiveCamera
            {
                FieldOfView = 45,
                Position = new Point3D(10, 10, 10),
                LookDirection = new Vector3D(-10, -10, -10),
                UpDirection = new Vector3D(0, 0, 1),
                FarPlaneDistance = 5000000
            };

            // setup lighting
            AmbientLightColor = Colors.DimGray;
            DirectionalLightColor = Colors.White;

            // floor plane grid
            Grid = LineBuilder.GenerateGrid(new Vector3(0, 0, 1), -5, 5, -5, 5);
            GridColor = Colors.Black;
            GridTransform = new TranslateTransform3D(0, 0, 0);
        }

        #endregion
    }
}
