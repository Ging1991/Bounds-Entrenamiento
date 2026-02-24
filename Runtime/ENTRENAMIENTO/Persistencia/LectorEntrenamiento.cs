using System.Collections.Generic;
using Ging1991.Persistencia.Lectores;

namespace Bounds.Entrenamiento {

	public class LectorEntrenamiento : LectorGenerico<LectorEntrenamiento.ListaDato> {

		public LectorEntrenamiento(string direccion) : base(direccion, TipoLector.DINAMICO) {
			if (!ExistenDatos()) {
				ListaDato listaDato = new();
				listaDato.lista = new();
				Guardar(new ListaDato());
			}
		}


		[System.Serializable]
		public class ListaDato {

			public List<EntrenamientoBD> lista;

		}


		public EntrenamientoBD LeerEntrenamientoBD(string nombre) {
			EntrenamientoBD ret = null;
			foreach (var dato in Leer().lista) {
				if (dato.nombre == nombre) {
					ret = dato;
				}
			}
			if (ret != null)
				return ret;
			return Crear(nombre);
		}


		private EntrenamientoBD Crear(string nombre) {
			ListaDato listaDato = Leer();
			EntrenamientoBD dato = new() {
				nombre = nombre,
				habilitado = true,
				derrotas = 0,
				victorias = 0
			};
			listaDato.lista.Add(dato);
			Guardar();
			return dato;
		}

	}

}