using System.Diagnostics;
using TaskBussines;
using TaskBussines.Interfaces;
using TaskData;
using TaskData.Interfaces;

namespace TestTaskManage
{
    public class TaskServicePerformanceTest
    {
        private readonly ITasksService _service;
        private readonly ITaskInformation _repository; // Dependencia real  
        public TaskServicePerformanceTest()
        {
            _repository = new TaskInformation(); // Usando una implementación real
            _service = new TasksService(_repository);
        }

        [Fact]
        public void CrearTareas_DeberiaSerRapido()
        {
            // Arrange            

            // Act 
            var stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < 1000; i++)
            {
                _service.CrearTarea($"Tarea {i}");
            }

            stopwatch.Stop();

            // Assert
            Assert.True(stopwatch.ElapsedMilliseconds < 5000, "La creación de 1000 tareas debería tomar menos de 5 segundos");

        }
    }
}
