using Bounds.Infraestructura;
using Bounds.Modulos.Persistencia;
using Bounds.Persistencia.Parametros;
using Ging1991.Persistencia.Direcciones;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Bounds.Entrenamiento {

	public class ControlEntrenamiento : MonoBehaviour {

		public MusicaDeFondo musicaDeFondo;
		public ParametrosControl parametrosControl;

		void Start() {
			parametrosControl.Inicializar();
			musicaDeFondo.Inicializar(new DireccionRecursos("Musica", "Fondo").Generar());
		}

		public void volver() {
			SceneManager.LoadScene(parametrosControl.parametros.escenaPadre);
		}


	}

}