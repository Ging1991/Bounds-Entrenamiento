using System.Collections.Generic;
using Bounds.Global;
using Bounds.Global.Mazos;
using Bounds.Modulos.Persistencia;
using Bounds.Persistencia;
using Bounds.Persistencia.Parametros;
using Ging1991.Core;
using Ging1991.Persistencia.Direcciones;
using Ging1991.Persistencia.Lectores;
using UnityEngine.SceneManagement;

namespace Bounds.Entrenamiento {

	public class ControlEntrenamiento : SingletonMonoBehaviour<ControlEntrenamiento> {

		public MusicaDeFondo musicaDeFondo;
		public ParametrosControl parametrosControl;
		private LectorEntrenamiento lectorEntrenamiento;
		private Billetera billetera;
		private Configuracion configuracion;
		private Direccion direccionMazos;

		void Start() {
			parametrosControl.Inicializar();
			ParametrosEscena parametros = parametrosControl.parametros;

			musicaDeFondo.Inicializar(parametros.direcciones["MUSICA_DE_FONDO"]);
			lectorEntrenamiento = new(parametros.direcciones["ENTRENAMIENTO"]);
			billetera = new(parametros.direcciones["BILLETERA"]);
			configuracion = new(parametros.direcciones["CONFIGURACION"]);
			direccionMazos = new DireccionRecursos(parametros.direcciones["ENTRENAMIENTO_MAZOS"]);
			IlustradorRecursos ilustrador = new(new DireccionRecursos(parametros.direcciones["PERSONAJES_MINIATURA"]));
			Dictionary<string, string> nombres = new LectorMapa<string, string>(parametros.direcciones["PERSONAJES_NOMBRES"], TipoLector.RECURSOS).LeerMapa();

			foreach (var oponente in FindObjectsOfType<Oponente>()) {
				EntrenamientoBD entrenamientoBD = lectorEntrenamiento.LeerEntrenamientoBD(oponente.codigo);
				oponente.Inicializar(
					ilustrador.GetElemento(oponente.codigo),
					nombres[oponente.codigo],
					entrenamientoBD.victorias,
					entrenamientoBD.derrotas
				);
			}

		}


		public void Volver() {
			SceneManager.LoadScene(parametrosControl.parametros.escenaPadre);
		}


		public void JugadorDuelo(string codigo, string nombre) {

			GlobalDuelo parametros = GlobalDuelo.GetInstancia();

			parametros.modo = "ENTRENAMIENTO";
			parametros.finalizarDuelo = new FinalizarEntrenamiento(codigo, lectorEntrenamiento, billetera);

			parametros.jugadorLP1 = 3000;
			parametros.jugadorLP2 = 3000;

			parametros.jugadorNombre1 = configuracion.GetNombre();
			parametros.jugadorNombre2 = nombre;

			parametros.jugadorMiniatura1 = "LAUNIX";
			parametros.jugadorMiniatura2 = codigo;

			Mazo mazo1 = new MazoJugador(MazoJugador.GetPredeterminado());
			parametros.mazo1 = mazo1.cartas;
			parametros.mazoVacio1 = mazo1.principalVacio;

			if (codigo == "CUENTACUENTOS") {
				parametros.mazo2 = mazo1.cartas;
				parametros.mazoVacio2 = mazo1.principalVacio;
			}
			else {
				Mazo mazo = new MazoEntrenamiento(direccionMazos.Generar(codigo));
				parametros.mazo2 = mazo.cartas;
				parametros.mazoVacio2 = mazo.principalVacio;
			}
			SceneManager.LoadScene("DUELO");
		}

		public class MazoEntrenamiento : MazoRecursos {

			public MazoEntrenamiento(string direccion) : base(direccion) { }

		}

	}

}