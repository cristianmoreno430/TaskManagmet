using TaskBussines;
using TaskBussines.Interfaces;
using TaskData;
using TaskData.Interfaces;

namespace TestTaskManage
{
    [Trait("Category", "Regression")]
    public class TaskServiceRegressionTest
    {
        private readonly ITasksService _service;
        private readonly ITaskInformation _repository; // Dependencia real  
        public TaskServiceRegressionTest()
        {
            _repository = new TaskInformation(); // Usando una implementación real
            _service = new TasksService(_repository);
        }

        [Fact]
        public void CrearTarea_DeberiaSeguirFuncionandoDespuesDeCambios()
        {
            // Arrange

            // Act 
            var tarea = _service.CrearTarea("Estudiar");

            // Assert
            Assert.NotNull(tarea);
            Assert.Equal("Estudiar", tarea.Nombre);
            Assert.False(tarea.Completada);
        }
    }
}
