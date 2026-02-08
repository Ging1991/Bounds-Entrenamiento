using System.Collections.Generic;
using Bounds.Global.Mazos;
using Bounds.Infraestructura;
using Bounds.Persistencia;
using Bounds.Persistencia.Datos;
using Ging1991.Persistencia.Direcciones;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Bounds.Entrenamiento {

	public class PjDesafiar : MonoBehaviour {

		public int pj;
		public string nombre;
		public string avatar;

		public GameObject nombreOBJ;
		public GameObject victoriasOBJ;
		public GameObject derrotasOBJ;

		void Start() {
			nombreOBJ.GetComponentInChildren<Text>().text = nombre;
			LectorEntrenamiento lector = LectorEntrenamiento.GetInstancia();
			SetEstadisticas(lector.LeerVictorias(nombre), lector.LeerDerrotas(nombre));
		}


		void OnMouseDown() {
			GlobalDuelo parametros = GlobalDuelo.GetInstancia();

			parametros.modo = "ENTRENAMIENTO";
			parametros.finalizarDuelo = new Fin();

			parametros.jugadorLP1 = 3000;
			parametros.jugadorLP2 = 3000;

			parametros.jugadorNombre1 = "Launix";
			parametros.jugadorNombre2 = nombre;

			parametros.jugadorMiniatura1 = "LAUNIX";
			parametros.jugadorMiniatura2 = avatar;

			Global.Mazo mazo1 = new MazoJugador(MazoJugador.GetPredeterminado());

			MazoBD mazoBD = new MazoBD();
			List<string> cartas = new List<string>();
			foreach (var carta in GetCartas(pj))
				cartas.Add($"{carta}_A_N_1");
			mazoBD.cartas = cartas;

			Global.Mazo mazo2 = new MazoSF(mazoBD);

			parametros.mazo1 = mazo1.cartas;
			parametros.mazo2 = (pj == 0) ? mazo1.cartas : mazo2.cartas;

			parametros.mazoVacio1 = mazo1.principalVacio;
			parametros.mazoVacio2 = mazo2.principalVacio;

			SceneManager.LoadScene("DUELO");
		}


		public void SetEstadisticas(int victorias, int derrotas) {
			derrotasOBJ.GetComponentInChildren<Text>().text = $"{derrotas}";
			victoriasOBJ.GetComponentInChildren<Text>().text = $"{victorias}";
		}


		private List<int> GetCartas(int pj) {
			List<int> cartas = new List<int>() { 1, 2, 3, 1, 2, 3, 1, 2, 3, 4 };
			if (pj == 1)
				cartas = new List<int>() { 45, 45, 45, 46, 46, 46, 47, 53, 53, 53, 54, 54, 54, 55, 56, 56, 56, 91, 91, 91, 92, 92, 92, 26, 26, 26, 93, 95, 95, 95, 98, 98, 98, 101, 102, 103, 113, 113, 114, 116 };
			if (pj == 2)
				cartas = new List<int>() { 234, 234, 234, 198, 197, 193, 193, 192, 192, 192, 191, 191, 191, 189, 189, 189, 187, 187, 187, 184, 105, 103, 103, 102, 101, 101, 90, 77, 77, 77, 33, 33, 33, 20, 19, 19, 19, 18, 18, 18 };
			if (pj == 3)
				cartas = new List<int>() { 81, 81, 81, 238, 238, 238, 76, 72, 72, 72, 59, 59, 59, 37, 37, 37, 234, 234, 234, 151, 151, 151, 84, 84, 84, 83, 83, 83, 49, 49, 49, 48, 48, 48, 43, 43, 43, 88, 88, 88 };
			if (pj == 4)
				cartas = new List<int>() { 11, 11, 11, 12, 12, 12, 13, 13, 13, 8, 8, 8, 9, 9, 9, 10, 88, 88, 88, 67, 67, 67, 151, 151, 151, 145, 145, 145, 147, 148, 149, 150, 38, 38, 38, 39, 39, 39, 40, 157 };
			if (pj == 5)
				cartas = new List<int>() { 161, 161, 161, 97, 28, 177, 166, 234, 234, 234, 171, 171, 171, 96, 96, 96, 27, 27, 27, 26, 26, 26, 32, 172, 16, 165, 165, 165, 94, 94, 94, 63, 63, 63, 15, 15, 15, 14, 14, 14 };
			if (pj == 6)
				cartas = new List<int>() { 138, 138, 129, 129, 129, 123, 123, 123, 99, 99, 99, 67, 67, 67, 59, 59, 59, 36, 36, 36, 34, 34, 34, 30, 29, 29, 29, 17, 17, 17, 10, 9, 9, 9, 8, 8, 8, 1, 1, 1 };
			if (pj == 7)
				cartas = new List<int>() { 1, 42, 56, 105, 120, 172, 17, 191, 161, 238, 1, 42, 56, 105, 120, 172, 17, 191, 161, 238, 1, 42, 56, 105, 120, 172, 17, 191, 161, 238, 1, 42, 56, 105, 120, 172, 17, 191, 161, 238 };
			return cartas;
		}

		public class Fin : IFinalizarDuelo {
			public void FinalizarDuelo(int jugadorGanador) {
				Configuracion configuracion = new Configuracion(new DireccionDinamica("CONFIGURACION", "CONFIGURACION.json").Generar());
				GlobalDuelo parametros = GlobalDuelo.GetInstancia();

				LectorEntrenamiento lectorEntrenamiento = LectorEntrenamiento.GetInstancia();
				if (jugadorGanador == 1)
					lectorEntrenamiento.IncrementarVictorias(parametros.jugadorNombre2);
				else
					lectorEntrenamiento.IncrementarDerrotas(parametros.jugadorNombre2);

				Billetera billetera = new(new DireccionDinamica("CONFIGURACION", "BILLETERA.json").Generar());
				billetera.GanarOro(300);
				ControlEscena escena = ControlEscena.GetInstancia();
				escena.CambiarEscena_entrenamiento();
			}

		}

	}

}