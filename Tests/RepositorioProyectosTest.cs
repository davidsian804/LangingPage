using LangingPage.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    internal class RepositorioProyectosTest
    {
        [TestMethod]
        public void ObtenerProyectos_DebeRetornarListaProyectos()
        {
            // Arrange
            RepositorioProyectos repositorio = new RepositorioProyectos();

            // Act
            var proyectos = repositorio.ObtenerProyectos();

            // Assert
            Assert.IsNotNull(proyectos);
            Assert.AreEqual(3, proyectos.Count); // Verificar que se retorne una lista de 3 proyectos (como se definió en el método original)
        }
    }
}
