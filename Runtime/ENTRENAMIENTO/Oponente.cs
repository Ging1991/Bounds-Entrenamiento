using UnityEngine;
using UnityEngine.UI;

namespace Bounds.Entrenamiento {

	public class Oponente : MonoBehaviour {

		public string codigo;
		public Image ilustracionOBJ;
		public Text nombreOBJ;
		public Text victoriasOBJ;
		public Text derrotasOBJ;

		public void Inicializar(Sprite ilustracion, string nombre, int victorias, int derrotas) {
			ilustracionOBJ.sprite = ilustracion;
			nombreOBJ.text = nombre;
			victoriasOBJ.text = $"{victorias}";
			derrotasOBJ.text = $"{derrotas}";
		}

		void OnMouseDown() {
			ControlEntrenamiento.Instancia.JugadorDuelo(codigo, nombreOBJ.text);
		}

	}

}