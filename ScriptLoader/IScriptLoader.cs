using BasicObjectsLibrary.Models.Subjects;

namespace ScriptObjectLoader.ScriptLoader
{
    public interface IScriptLoader
    {
        Subject3DWrapperModel Load(string scriptExecutiveFileName);
    }
}