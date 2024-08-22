using TaskBussines;
using TaskBussines.Interfaces;
using TaskData;
using TaskData.Interfaces;

namespace TestTaskManage
{
    public class TaskServiceAcceptanceTest
    {
        private readonly ITasksService _service;
        private readonly ITaskInformation _repository; // Dependencia real  
        public TaskServiceAcceptanceTest()
        {
            _repository = new TaskInformation(); // Usando una implementación real
            _service = new TasksService(_repository);
        }

        [Fact]
        public void UsuarioPuedeGestionarTareas_Exitosamente()
        {
            // Arrange

            // Act 
            var Nombre = _service.GetFake(1);
            // Assert
            Assert.Equal("Estudiar", Nombre);

            // Act 
            var tarea = _service.CrearTarea("Planear reunión");
            // Assert
            Assert.NotNull(tarea);
            Assert.Equal("Planear reunión", tarea.Nombre);

            // Act 
            var actualizarResultado = _service.ActualizarTarea(tarea.Id, "Reunión planificada", true);
            Assert.True(actualizarResultado);

            // Act 
            var tareas = _service.ObtenerTareas();
            // Assert
            Assert.Single(tareas);
            Assert.True(tareas[0].Completada);

            // Act 
            var eliminarResultado = _service.EliminarTarea(tarea.Id);
            // Assert
            Assert.True(eliminarResultado);
            Assert.Empty(_service.ObtenerTareas()); 
        }
    }
}
