using TaskData.Dtos;

namespace TaskData.Interfaces
{
    public interface ITaskInformation
    {
        void Agregar(TaskDto tarea);
        TaskDto? ObtenerPorId(int id);        
        List<TaskDto> ObtenerTodas();
        void Actualizar(TaskDto tarea);
        void Eliminar(TaskDto tarea);
    }
}