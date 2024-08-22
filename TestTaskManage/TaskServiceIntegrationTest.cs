using TaskBussines;
using TaskBussines.Interfaces;
using TaskData;
using TaskData.Interfaces;

namespace TestTaskManage
{
    public class WebApplicationFactoryIntegrationTest
    {
        private readonly ITasksService _service; 
        private readonly ITaskInformation _repository; // Dependencia real        

        public WebApplicationFactoryIntegrationTest()
        {
            _repository = new TaskInformation(); // Usando una implementación real
            _service = new TasksService(_repository);
        }

        [Fact]
        public void CrearYObtenerTareas_DeberiaRetornarLasTareasAgregadas()
        {
            // Arrange
            _service.CrearTarea("Estudiar");
            _service.CrearTarea("Leer");

            // Act 
            var tareas = _service.ObtenerTareas();

            // Assert
            Assert.Equal(2, tareas.Count);
            Assert.Equal("Estudiar", tareas[0].Nombre);
            Assert.Equal("Leer", tareas[1].Nombre);
        }
    }
}
