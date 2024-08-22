using TaskData.Dtos;

namespace TaskBussines.Interfaces
{
    public interface ITasksService
    {
        string GetStub(int id);
        string GetFake(int id);
        bool ActualizarTarea(int id, string nombre, bool completada);
        TaskDto CrearTarea(string nombre);
        bool EliminarTarea(int id);
        List<TaskDto> ObtenerTareas();
    }
}