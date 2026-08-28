using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CreanNeuronasCapas.Form1;

namespace CreanNeuronasCapas
{
    public partial class Form1 : Form
    {
        double w0_1_1, w1_1_1, w2_1_1;
        double w0_2_1, w1_2_1, w2_2_1;
        double w0_1_2, w1_1_2, w2_1_2;
        double s1, y1;
        int c;
        double razon, errores, tasaAprendizaje;
        public Form1()
        {
            InitializeComponent();
        }

        private void backp_Click(object sender, EventArgs e)
        {
            if (Compuertas.Text == "AND")
            {

                // Inicializar la tabla "Tabla"
                Tabla.Rows.Clear();
                Tabla.Columns.Clear();
                lbs.Items.Clear();
                // Agregar nuevas columnas con encabezados "x1", "x2", "Yesp"
                Compu2();
                //Asignar binario de 2x
                valoresX2();
                //Agregar valores de las filas de Yesp
                Tabla.Rows[0].Cells["Yesp"].Value = 0;
                Tabla.Rows[1].Cells["Yesp"].Value = 0;
                Tabla.Rows[2].Cells["Yesp"].Value = 0;
                Tabla.Rows[3].Cells["Yesp"].Value = 1;
            }

            if (Compuertas.Text == "OR")
            {

                // Inicializar la tabla "Tabla"
                Tabla.Rows.Clear();
                Tabla.Columns.Clear();
                lbs.Items.Clear();
                // Agregar nuevas columnas con encabezados "x1", "x2", "Yesp"
                Compu2();
                //Asignar binario de 2x
                valoresX2();
                //Agregar valores de las filas de Yesp
                Tabla.Rows[0].Cells["Yesp"].Value = 0;
                Tabla.Rows[1].Cells["Yesp"].Value = 1;
                Tabla.Rows[2].Cells["Yesp"].Value = 1;
                Tabla.Rows[3].Cells["Yesp"].Value = 1;
            }

            if (Compuertas.Text == "XOR")
            {
                // Inicializar la tabla "Tabla"
                Tabla.Rows.Clear();
                Tabla.Columns.Clear();
                lbs.Items.Clear();
                // Agregar nuevas columnas con encabezados "x1", "x2", "Yesp"
                Compu2();
                //Asignar binario de 2x
                valoresX2();
                //Agregar valores de las filas de Yesp
                Tabla.Rows[0].Cells["Yesp"].Value = 0;
                Tabla.Rows[1].Cells["Yesp"].Value = 1;
                Tabla.Rows[2].Cells["Yesp"].Value = 1;
                Tabla.Rows[3].Cells["Yesp"].Value = 0;
                c = int.Parse(capas.Text);
                tasaAprendizaje = double.Parse(razona.Text);
                //razon = int.Parse(razona.Text);
                //errores = int.Parse(error.Text);

                List<int> estructura = new List<int>();
                foreach (DataGridViewRow fila in CaNe.Rows)
                {
                    if (fila.Cells["NeuronasCapa"].Value != null)
                    {
                        try
                        {
                            int numeroNeuronas = int.Parse(fila.Cells["NeuronasCapa"].Value.ToString());
                            estructura.Add(numeroNeuronas);
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Por favor, ingrese un número válido de neuronas.");
                            return;
                        }
                    }
                }

                if (estructura.Count > 0)
                {
                    RedNeuronal red = new RedNeuronal(estructura.ToArray());

                    // Suponiendo que "Tabla" tiene los datos de entrada para el XOR
                    for (int i = 0; i < Tabla.Rows.Count; i++)
                    {
                        double x1 = Convert.ToDouble(Tabla.Rows[i].Cells["x1"].Value);
                        double x2 = Convert.ToDouble(Tabla.Rows[i].Cells["x2"].Value);

                        List<double> salida = red.Feedforward(new List<double> { x1, x2 });
                        Tabla.Rows[i].Cells["Yres"].Value = salida[0]; // Suponiendo que la salida es un solo valor
                    }

                    


                }
                else
                {
                    MessageBox.Show("Por favor, ingrese la estructura de la red.");
                }

                if (estructura.Count > 0)
                {
                    RedNeuronal red = new RedNeuronal(estructura.ToArray());
                    double errorTotal = 0.0;

                    for (int i = 0; i < Tabla.Rows.Count; i++)
                    {
                        double x1 = Convert.ToDouble(Tabla.Rows[i].Cells["x1"].Value);
                        double x2 = Convert.ToDouble(Tabla.Rows[i].Cells["x2"].Value);
                        double yEsperado = Convert.ToDouble(Tabla.Rows[i].Cells["Yesp"].Value);

                        List<double> salida = red.Feedforward(new List<double> { x1, x2 });
                        Tabla.Rows[i].Cells["Yres"].Value = salida[0];

                        double errorIndividual = 0.5 * Math.Pow(yEsperado - salida[0], 2);
                        errorTotal += errorIndividual;
                    }

                    // Mostrar el error total en algún lugar, por ejemplo, en un ListBox
                    lbs.Items.Add("Error total de la red: " + errorTotal.ToString());
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese la estructura de la red.");
                }

                if (estructura.Count > 0)
                {
                    RedNeuronal red = new RedNeuronal(estructura.ToArray());
                    List<double> erroresDelta = new List<double>();

                    for (int i = 0; i < Tabla.Rows.Count; i++)
                    {
                        double x1 = Convert.ToDouble(Tabla.Rows[i].Cells["x1"].Value);
                        double x2 = Convert.ToDouble(Tabla.Rows[i].Cells["x2"].Value);
                        double yEsperado = Convert.ToDouble(Tabla.Rows[i].Cells["Yesp"].Value);

                        List<double> salida = red.Feedforward(new List<double> { x1, x2 });
                        Tabla.Rows[i].Cells["Yres"].Value = salida[0];

                        double errorDelta = -(yEsperado - salida[0]) * salida[0] * (1 - salida[0]);
                        erroresDelta.Add(errorDelta);
                    }

                    // Mostrar los errores delta para cada entrada en un ListBox
                    foreach (double error in erroresDelta)
                    {
                        lbs.Items.Add("Error Delta: " + error.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese la estructura de la red.");
                }


                if (estructura.Count > 0)
                {
                    RedNeuronal red = new RedNeuronal(estructura.ToArray());
                    

                     AplicarBackpropagation(red);
                    
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese la estructura de la red.");
                }




            }


            if (Compuertas.Text == "Mayoria-Simple")
            {
                // Inicializar la tabla "Tabla"
                Tabla.Rows.Clear();
                Tabla.Columns.Clear();
                lbs.Items.Clear();
                // Agregar nuevas columnas con encabezados "x1", "x2", "x3", "Yesp"
                Compu3();
                //Asignar binario de 3x
                valoresX3();
                //Agregar valores de las filas de Yesp
                Tabla.Rows[0].Cells["Yesp"].Value = 0;
                Tabla.Rows[1].Cells["Yesp"].Value = 0;
                Tabla.Rows[2].Cells["Yesp"].Value = 0;
                Tabla.Rows[3].Cells["Yesp"].Value = 1;
                Tabla.Rows[4].Cells["Yesp"].Value = 0;
                Tabla.Rows[5].Cells["Yesp"].Value = 1;
                Tabla.Rows[6].Cells["Yesp"].Value = 1;
                Tabla.Rows[7].Cells["Yesp"].Value = 1;
            }

            if (Compuertas.Text == "Paridad")
            {
                // Inicializar la tabla "Tabla"
                Tabla.Rows.Clear();
                Tabla.Columns.Clear();
                lbs.Items.Clear();
                // Agregar nuevas columnas con encabezados "x1", "x2", "x3", "Yesp"
                Compu3();
                //Asignar binario de 3x
                valoresX3();
                //Agregar valores de las filas de Yesp
                Tabla.Rows[0].Cells["Yesp"].Value = 1;
                Tabla.Rows[1].Cells["Yesp"].Value = 0;
                Tabla.Rows[2].Cells["Yesp"].Value = 0;
                Tabla.Rows[3].Cells["Yesp"].Value = 1;
                Tabla.Rows[4].Cells["Yesp"].Value = 0;
                Tabla.Rows[5].Cells["Yesp"].Value = 1;
                Tabla.Rows[6].Cells["Yesp"].Value = 1;
                Tabla.Rows[7].Cells["Yesp"].Value = 0;
            }
            if (Compuertas.Text == "Ejercicio")
            {

                // Inicializar la tabla "Tabla"
                Tabla.Rows.Clear();
                Tabla.Columns.Clear();
                lbs.Items.Clear();

                // Agregar la columna "Yesp" a la tabla "Tabla"
                Tabla.Columns.Add("Yesp", "Yesp");
                Tabla.Columns.Add("Ycalc", "Ycalc");
                Tabla.Columns.Add("Epoca", "Epoca");

                //Agregar valores de las filas de Yesp
                Tabla.Rows[0].Cells["Yesp"].Value = 1;
                Tabla.Rows[1].Cells["Yesp"].Value = 0;
                Tabla.Rows[2].Cells["Yesp"].Value = 1;
                Tabla.Rows[3].Cells["Yesp"].Value = 0;
                Tabla.Rows[4].Cells["Yesp"].Value = 1;
                Tabla.Rows[5].Cells["Yesp"].Value = 0;

                //Agregar valores de las filas de X1
                Tabla.Rows[0].Cells["x1"].Value = 2;
                Tabla.Rows[1].Cells["x1"].Value = 0;
                Tabla.Rows[2].Cells["x1"].Value = 2;
                Tabla.Rows[3].Cells["x1"].Value = 0;
                Tabla.Rows[4].Cells["x1"].Value = 1;
                Tabla.Rows[5].Cells["x1"].Value = 1;
                //Agregar valores de las filas de X2
                Tabla.Rows[0].Cells["x2"].Value = 0;
                Tabla.Rows[1].Cells["x2"].Value = 0;
                Tabla.Rows[2].Cells["x2"].Value = 2;
                Tabla.Rows[3].Cells["x2"].Value = 1;
                Tabla.Rows[4].Cells["x2"].Value = 1;
                Tabla.Rows[5].Cells["x2"].Value = 2;
            }
        }
        public void Compu2()
        {
            // Agregar nuevas columnas con encabezados "x1", "x2", "Yesp"
            string[] ColumnasX = new string[]
            {
                "x1", "x2", "Yesp", "Yres"
            };
            // Agregar nuevas columnas con encabezados "x1", "x2", "Yesp"
            foreach (string columna in ColumnasX)
            {
                Tabla.Columns.Add(columna, columna);
            }
            Tabla.Rows.Add(3);
        }
        public void Compu3()
        {
            // Agregar nuevas columnas con encabezados "x1", "x2", "x3", "Yesp"
            string[] ColumnasX2 = new string[]
            {
                "x1", "x2", "x3", "Yesp"
            };
            // Agregar nuevas columnas con encabezados "x1", "x2", "x3", "Yesp"
            foreach (string columna2 in ColumnasX2)
            {
                Tabla.Columns.Add(columna2, columna2);
            }
            Tabla.Rows.Add(7);
        }
        public void valoresX2()
        {
            //Agregar valores de las filas de X1
            Tabla.Rows[0].Cells["x1"].Value = 0;
            Tabla.Rows[1].Cells["x1"].Value = 0;
            Tabla.Rows[2].Cells["x1"].Value = 1;
            Tabla.Rows[3].Cells["x1"].Value = 1;
            //Agregar valores de las filas de X2
            Tabla.Rows[0].Cells["x2"].Value = 0;
            Tabla.Rows[1].Cells["x2"].Value = 1;
            Tabla.Rows[2].Cells["x2"].Value = 0;
            Tabla.Rows[3].Cells["x2"].Value = 1;
        }
        public void valoresX3()
        {
            //Agregar valores de las filas de x1
            Tabla.Rows[0].Cells["x1"].Value = 0;
            Tabla.Rows[1].Cells["x1"].Value = 0;
            Tabla.Rows[2].Cells["x1"].Value = 0;
            Tabla.Rows[3].Cells["x1"].Value = 0;
            Tabla.Rows[4].Cells["x1"].Value = 1;
            Tabla.Rows[5].Cells["x1"].Value = 1;
            Tabla.Rows[6].Cells["x1"].Value = 1;
            Tabla.Rows[7].Cells["x1"].Value = 1;
            //Agregar valores de las filas de x2
            Tabla.Rows[0].Cells["x2"].Value = 0;
            Tabla.Rows[1].Cells["x2"].Value = 0;
            Tabla.Rows[2].Cells["x2"].Value = 1;
            Tabla.Rows[3].Cells["x2"].Value = 1;
            Tabla.Rows[4].Cells["x2"].Value = 0;
            Tabla.Rows[5].Cells["x2"].Value = 0;
            Tabla.Rows[6].Cells["x2"].Value = 1;
            Tabla.Rows[7].Cells["x2"].Value = 1;
            //Agregar valores de las filas de x3
            Tabla.Rows[0].Cells["x3"].Value = 0;
            Tabla.Rows[1].Cells["x3"].Value = 1;
            Tabla.Rows[2].Cells["x3"].Value = 0;
            Tabla.Rows[3].Cells["x3"].Value = 1;
            Tabla.Rows[4].Cells["x3"].Value = 0;
            Tabla.Rows[5].Cells["x3"].Value = 1;
            Tabla.Rows[6].Cells["x3"].Value = 0;
            Tabla.Rows[7].Cells["x3"].Value = 1;
        }

        private void crear_Click(object sender, EventArgs e)
        {
            c = int.Parse(capas.Text);
            numerocapas();
        }

        private void numerocapas()
        {
            // Asegúrate de que la tabla tiene al menos 'c' filas
            AsegurarFilasEnCaNe(c);

            // Asignar valores de 1 a 'c' a la columna "CapaOculta"
            for (int i = 0; i < c; i++)
            {
                CaNe.Rows[i].Cells["CapaOculta"].Value = i + 1;
            }
        }

        private void AsegurarFilasEnCaNe(int numeroDeFilas)
        {
            // Añadir filas faltantes a la tabla si es necesario
            while (CaNe.Rows.Count < numeroDeFilas)
            {
                CaNe.Rows.Add();
            }
        }

        public class Neurona
        {
            public double UltimaActivacion { get; private set; }
            public List<double> Pesos { get; private set; }
            public double Sesgo { get; set; }

            public Neurona(int numeroEntradas)
            {
                Pesos = new List<double>();
                for (int i = 0; i < numeroEntradas; i++)
                {
                    Pesos.Add(RandomNumber());
                }
                Sesgo = RandomNumber();
            }

            private double RandomNumber() => new Random().NextDouble() * 2 - 1;

            public double Activar(List<double> entradas)
            {
                double suma = Sesgo;
                for (int i = 0; i < Pesos.Count; i++)
                {
                    suma += Pesos[i] * entradas[i];

                }
                UltimaActivacion = 1 / (1 + Math.Exp(-suma)); // Función sigmoide
                return UltimaActivacion;
            }

        }


        public class Capa
        {
            public List<double> ObtenerUltimasActivaciones()
            {
                return Neuronas.Select(neurona => neurona.UltimaActivacion).ToList();
            }

            public List<Neurona> Neuronas { get; private set; }

            public Capa(int numeroNeuronas, int numeroEntradasPorNeurona)
            {
                Neuronas = new List<Neurona>();
                for (int i = 0; i < numeroNeuronas; i++)
                {
                    Neuronas.Add(new Neurona(numeroEntradasPorNeurona));
                }
            }

            public List<double> Activar(List<double> entradas)
            {
                return Neuronas.Select(neurona => neurona.Activar(entradas)).ToList();
            }
        }

        public class RedNeuronal
        {
            public List<Capa> Capas { get; private set; }

            public RedNeuronal(int[] estructura)
            {
                Capas = new List<Capa>();
                for (int i = 0; i < estructura.Length; i++)
                {
                    int numeroEntradas = i == 0 ? estructura[i] : Capas[i - 1].Neuronas.Count;
                    Capas.Add(new Capa(estructura[i], numeroEntradas));
                }
            }

            public List<double> Feedforward(List<double> entradas)
            {
                foreach (var capa in Capas)
                {
                    entradas = capa.Activar(entradas);
                }
                return entradas;
            }

        }

        public List<List<double>> CalcularErrorCapasOcultas(RedNeuronal red, List<double> erroresDeltaCapaSalida, ListBox lbs)
        {
            List<List<double>> todosLosErrores = new List<List<double>>();

            for (int i = red.Capas.Count - 2; i >= 0; i--)
            {
                Capa capaOculta = red.Capas[i];
                List<double> erroresDeltaCapaOculta = new List<double>();

                for (int j = 0; j < capaOculta.Neuronas.Count; j++)
                {
                    double activacion = capaOculta.Neuronas[j].UltimaActivacion;
                    double error = activacion * (1 - activacion);

                    double sumaErrorPonderado = 0.0;
                    for (int k = 0; k < red.Capas[i + 1].Neuronas.Count; k++)
                    {
                        sumaErrorPonderado += erroresDeltaCapaSalida[k] * red.Capas[i + 1].Neuronas[k].Pesos[j];
                    }

                    error *= sumaErrorPonderado;
                    erroresDeltaCapaOculta.Add(error);

                    // Mostrar el error en el ListBox
                    lbs.Items.Add($"Error capa oculta {i + 1}, neurona {j + 1}: {error}");
                }

                erroresDeltaCapaSalida = erroresDeltaCapaOculta; // Preparar para la siguiente iteración
                todosLosErrores.Insert(0, erroresDeltaCapaOculta);
            }

            return todosLosErrores;
        }

        private void ActualizarUmbrales(Capa capa, List<double> erroresDelta)
        {
            for (int i = 0; i < capa.Neuronas.Count; i++)
            {
                capa.Neuronas[i].Sesgo -= tasaAprendizaje * erroresDelta[i];
            }
        }
        private void ActualizarPesos(Capa capa, Capa capaAnterior, List<double> erroresDelta)
        {
            for (int i = 0; i < capa.Neuronas.Count; i++)
            {
                for (int j = 0; j < capa.Neuronas[i].Pesos.Count; j++)
                {
                    double activacion = capaAnterior == null ? 0 : capaAnterior.Neuronas[j].UltimaActivacion;
                    capa.Neuronas[i].Pesos[j] -= tasaAprendizaje * erroresDelta[i] * activacion;
                    
                }
            }
        }
        public void AplicarBackpropagation(RedNeuronal red)
        {
            List<double> erroresDelta = new List<double>();// Inicializar con los errores de la capa de salida
            Capa capaSalida = red.Capas[red.Capas.Count - 1];

            for (int i = 0; i < capaSalida.Neuronas.Count; i++)
            {
                double salidaActual = capaSalida.Neuronas[i].UltimaActivacion;
                double salidaEsperada = 0.01; // Asumiendo que tienes esta lista disponible
                double error = (salidaEsperada - salidaActual) * salidaActual * (1 - salidaActual); // Para función sigmoide
                erroresDelta.Add(error);
            }

            for (int i = red.Capas.Count - 1; i >= 0; i--)
            {
                Capa capaActual = red.Capas[i];
                Capa capaAnterior = i > 0 ? red.Capas[i - 1] : null;

                ActualizarUmbrales(capaActual, erroresDelta);
                ActualizarPesos(capaActual, capaAnterior, erroresDelta);

                if (i > 0)
                {
                    List<double> nuevosErroresDelta = new List<double>();
                    Capa capaSiguiente = red.Capas[i];
                    for (int j = 0; j < capaAnterior.Neuronas.Count; j++)
                    {
                        double error = capaAnterior.Neuronas[j].UltimaActivacion * (1 - capaAnterior.Neuronas[j].UltimaActivacion);
                        double suma = 0;
                        for (int k = 0; k < capaSiguiente.Neuronas.Count; k++)
                        {
                            suma += capaSiguiente.Neuronas[k].Pesos[j] * erroresDelta[k];
                        }
                        error *= suma;
                        nuevosErroresDelta.Add(error);
                    }
                    erroresDelta = nuevosErroresDelta;
                }
            }
            
        }





    }
}
