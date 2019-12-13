using System.Collections.Generic;
using BasicObjectsLibrary.Managers.GeometryManager;
using BasicObjectsLibrary.Managers.MaterialManager;
using BasicObjectsLibrary.Models.Subjects;
using Microsoft.Scripting.Hosting;

namespace ScriptObjectLoader.ScriptLoader.Python
{
    public class PythonScriptLoader : IScriptLoader
    {
        protected ScriptEngine Engine { get; set; }
        protected ScriptScope Scope { get; set; }

        protected IGeometryManager GeometryManager { get; set; }
        protected IMaterialManager MaterialManager { get; set; }

        public PythonScriptLoader()
        {
#if DEBUG
            var options = new Dictionary<string, object> { ["Debug"] = true };
            Engine = IronPython.Hosting.Python.CreateEngine(options);
#else
            Engine = Python.CreateEngine();
#endif

            InitScope();
        }

        protected void InitScope()
        {
            Scope = Engine.CreateScope();

            InitClasses();
            InitManagers();
        }

        protected void InitClasses()
        {
            Engine.ExecuteFile(@"ScriptLoader\Python\Classes\object_wrapper.py", Scope);
        }

        protected void InitManagers()
        {
            GeometryManager = new GeometryManager();
            MaterialManager = new MaterialManager();

            Scope.SetVariable("GeometryManager", GeometryManager);
            Scope.SetVariable("MaterialManager", MaterialManager);
        }

        public Subject3DWrapperModel Load(string scriptExecutiveFileName)
        {
            Engine.ExecuteFile(scriptExecutiveFileName, Scope);
            var objectRepresentationFunc = Scope.GetVariable("GetObjectRepresentation");
            var objectRepresentation = objectRepresentationFunc();
            return new Subject3DWrapperModel(objectRepresentation);
        }
    }
}
