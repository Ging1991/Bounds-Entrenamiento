using Bounds.Persistencia.Parametros;
using Ging1991.Persistencia.Direcciones;

namespace Bounds.Tienda {

	public class ParametrosControlEntrenamiento : ParametrosControl {

		public override void SetParametros() {
			// ENTRENAMIENTO
			parametros.escenaPadre = "TEST";
			parametros.direcciones["MUSICA_DERROTA"] = new DireccionRecursos("Musica", "DERROTA").Generar();
			parametros.direcciones["MUSICA_VICTORIA"] = new DireccionRecursos("Musica", "VICTORIA").Generar();
			parametros.direcciones["MUSICA_TIENDA"] = new DireccionRecursos("Musica", "TIENDA").Generar();
			parametros.direcciones["PERSONAJES_NOMBRES"] = new DireccionRecursos("PERSONAJES", "NOMBRES").Generar();
			parametros.direcciones["SISTEMA"] = new DireccionRecursos("IDIOMAS/SISTEMA", "SISTEMA").Generar();
			parametros.direcciones["ENTRENAMIENTO_MAZOS"] = "MAZOS/ENTRENAMIENTO";
			parametros.direcciones["PERSONAJES_MINIATURA"] = "PERSONAJES/MINIATURAS";
			parametros.direcciones["ENTRENAMIENTO"] = new DireccionDinamica("ENTRENAMIENTO", "ENTRENAMIENTO.json").Generar();

			//OTROS
			parametros.direcciones["SOBRES"] = new DireccionDinamica("TIENDA", "SOBRES.json").Generar();
			parametros.direcciones["CONFIGURACION"] = new DireccionDinamica("CONFIGURACION", "CONFIGURACION.json").Generar();
			parametros.direcciones["BILLETERA"] = new DireccionDinamica("CONFIGURACION", "BILLETERA.json").Generar();
			parametros.direcciones["COLECCIONES"] = "COLECCIONES";
			parametros.direcciones["CARTA_NOMBRES"] = new DireccionRecursos("Cartas", "Nombres").Generar();
			parametros.direcciones["COFRE_RECURSOS"] = new DireccionRecursos("MAZOS", "COFRE").Generar();
			parametros.direcciones["COFRE"] = new DireccionDinamica("CONFIGURACION", "COFRE.json").Generar();
			parametros.direcciones["CARTA_CLASES"] = new DireccionRecursos("Cartas", "Clases").Generar();
			parametros.direcciones["CARTA_TIPOS"] = new DireccionRecursos("Cartas", "Tipos").Generar();
			parametros.direcciones["CARTA_INVOCACIONES"] = new DireccionRecursos("Cartas", "Invocaciones").Generar();
			parametros.direcciones["CARTAS_RECURSO"] = "Cartas/Imagenes";
			parametros.direcciones["CARTAS_DINAMICA"] = "IMAGENES/Cartas/Imagenes";
		}

	}

}