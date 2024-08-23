using Moq;
using TaskBussines;
using TaskBussines.Interfaces;
using TaskData.Dtos;
using TaskData.Interfaces;

namespace TestTaskManage
{
    public class TaskServiceUnitTest
    {


        private readonly Mock<ITaskInformation> _mockRepository;
        private readonly ITasksService _service;
        private List<TaskDto> _tareas;
        public TaskServiceUnitTest()
        {
            _tareas = new List<TaskDto>();
            _mockRepository = new Mock<ITaskInformation>();
            _service = new TasksService(_mockRepository.Object); // Usando un mock

            // Configura el mock para devolver la lista de tareas
            _mockRepository.Setup(r => r.ObtenerTodas()).Returns(() => _tareas);

            // Configura el mock para reflejar los cambios en la lista cuando se llama a Agregar
            _mockRepository.Setup(r => r.Agregar(It.IsAny<TaskDto>())).Callback<TaskDto>(tarea => _tareas.Add(tarea));

            // Configura el mock para devolver la tarea correcta por su ID
            _mockRepository.Setup(r => r.ObtenerPorId(It.IsAny<int>())).Returns<int>(id => _tareas.FirstOrDefault(t => t.Id == id));

            // Configura el mock para eliminar la tarea de la lista cuando se llama a Eliminar
            _mockRepository.Setup(r => r.Eliminar(It.IsAny<TaskDto>())).Callback<TaskDto>(tarea => _tareas.Remove(tarea));

        }

        [Fact]
        public void CrearTarea_DeberiaAgregarUnaNuevaTarea()
        {
            // Arrange: En esta sección, configuras el entorno para la prueba.
            // Esto incluye instanciar objetos y configurar cualquier dato o estado inicial necesario para que la prueba pueda ejecutarse.


            // Act: Aquí es donde ejecutas la acción que estás probando.
            // Es la parte en la que llamas al método o funcionalidad que quieres verificar.
            var tarea = _service.CrearTarea("Estudiar");

            // Assert: En esta sección, verificas que el resultado de la acción sea el esperado.
            // Esto se hace comparando el resultado actual con el resultado esperado utilizando
            // métodos de aserción como Assert.Single, Assert.Equal, etc.
            Assert.NotNull(tarea);
            Assert.Equal("Estudiar", tarea.Nombre);
            Assert.False(tarea.Completada);
            Assert.Single(_service.ObtenerTareas());
        }

        [Fact]
        public void ActualizarTarea_DeberiaActualizarLaTareaExistente()
        {
            // Arrange
            var tarea = _service.CrearTarea("Estudiar");

            // Act
            var resultado = _service.ActualizarTarea(tarea.Id, "Leer", true);

            // Assert:
            Assert.True(resultado);
            Assert.Equal("Leer", tarea.Nombre);
            Assert.True(tarea.Completada);
        }

        [Fact]
        public void EliminarTarea_DeberiaEliminarLaTareaExistente()
        {
            // Arrange
            var tarea = _service.CrearTarea("Estudiar");

            // Act
            var resultado = _service.EliminarTarea(tarea.Id);

            // Assert:
            Assert.True(resultado);
            Assert.Empty(_service.ObtenerTareas());
        }
    }
}