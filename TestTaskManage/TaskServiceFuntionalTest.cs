using TaskBussines;
using TaskBussines.Interfaces;
using TaskData;
using TaskData.Interfaces;

namespace TestTaskManage
{
    public  class TaskServiceFuntionalTest
    {
        private readonly ITasksService _service;
        private readonly ITaskInformation _repository; // Dependencia real    
        public TaskServiceFuntionalTest()
        {
            _repository = new TaskInformation(); // Usando una implementación real
            _service = new TasksService(_repository);
        }

        [Fact]
        public void FlujoCompleto_DeberiaCrearActualizarObtenerYEliminarTareas()
        {
            // Arrange

            // Act 
            var Nombre = _service.GetStub(1);
            // Assert
            Assert.Equal("Estudiar", Nombre);

            // Act 
            var tarea = _service.CrearTarea("Estudiar");

            // Assert
            Assert.NotNull(tarea);

            // Act 
            var actualizarResultado = _service.ActualizarTarea(tarea.Id, "Leer", true);
            // Assert
            Assert.True(actualizarResultado);

            // Act 
            var tareas = _service.ObtenerTareas();
            // Assert
            Assert.Single(tareas);

            // Act 
            var eliminarResultado = _service.EliminarTarea(tarea.Id);
            // Assert
            Assert.True(eliminarResultado);
            Assert.Empty(_service.ObtenerTareas());
        }
    }
}
