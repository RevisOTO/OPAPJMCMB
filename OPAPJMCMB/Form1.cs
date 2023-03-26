using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OPAPJMCMB
{
    public partial class Form1 : Form
    {
        List<Tuple<string, string, string>> PalabrasReservadas = new List<Tuple<string, string, string>>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Palabras reservadas
            PalabrasReservadas.Add(new Tuple<string, string, string>("readline", "PR01", "Inst"));
            PalabrasReservadas.Add(new Tuple<string, string, string>("println", "PR02", "Inst"));

            PalabrasReservadas.Add(new Tuple<string, string, string>("string", "PR03", "Type"));
            PalabrasReservadas.Add(new Tuple<string, string, string>("int", "PR04", "Type"));
            PalabrasReservadas.Add(new Tuple<string, string, string>("bool", "PR05", "Type"));
            PalabrasReservadas.Add(new Tuple<string, string, string>("double", "PR06", "Type"));
            PalabrasReservadas.Add(new Tuple<string, string, string>("continue", "PR07", "Type"));
            PalabrasReservadas.Add(new Tuple<string, string, string>("char", "PR15", "Type"));

            //If y Loops
            PalabrasReservadas.Add(new Tuple<string, string, string>("for", "PR08", "AniFor"));

            PalabrasReservadas.Add(new Tuple<string, string, string>("while", "PR09", "Ani"));
            PalabrasReservadas.Add(new Tuple<string, string, string>("do", "PR10", "Ani"));
            PalabrasReservadas.Add(new Tuple<string, string, string>("if", "PR11", "Ani"));

            PalabrasReservadas.Add(new Tuple<string, string, string>("else", "PR12", "AniElse"));

            //Otros
            PalabrasReservadas.Add(new Tuple<string, string, string>("begin", "PR13", "Other"));
            PalabrasReservadas.Add(new Tuple<string, string, string>("end", "PR14", "Other"));

            //Identificadores
            PalabrasReservadas.Add(new Tuple<string, string, string>("ide", "IDE", "Ide"));

            //Operadores
            PalabrasReservadas.Add(new Tuple<string, string, string>("+", "OPER1", "Ope"));
            PalabrasReservadas.Add(new Tuple<string, string, string>("-", "OPER2", "Ope"));
            PalabrasReservadas.Add(new Tuple<string, string, string>("/", "OPER3", "Ope"));
            PalabrasReservadas.Add(new Tuple<string, string, string>("*", "OPER4", "Ope"));
            PalabrasReservadas.Add(new Tuple<string, string, string>("^", "OPER5", "Ope"));

            //Operadores Relacionales
            PalabrasReservadas.Add(new Tuple<string, string, string>(">", "COMP01", "Rel"));
            PalabrasReservadas.Add(new Tuple<string, string, string>("<", "COMP02", "Rel"));
            PalabrasReservadas.Add(new Tuple<string, string, string>(">=", "COMP03", "Rel"));
            PalabrasReservadas.Add(new Tuple<string, string, string>("<=", "COMP04", "Rel"));
            PalabrasReservadas.Add(new Tuple<string, string, string>("<>", "COMP05", "Rel"));
            PalabrasReservadas.Add(new Tuple<string, string, string>("==", "COMP06", "Rel"));

            //Operadores Logicos
            PalabrasReservadas.Add(new Tuple<string, string, string>("&&", "LOG01", "Log"));
            PalabrasReservadas.Add(new Tuple<string, string, string>("||", "LOG02", "Log"));
            PalabrasReservadas.Add(new Tuple<string, string, string>("!", "LOG03", "Log"));

            //Caracteres especiales
            PalabrasReservadas.Add(new Tuple<string, string, string>("@", "CE01", "Esp"));
            PalabrasReservadas.Add(new Tuple<string, string, string>("$", "CE02", "Esp"));
            PalabrasReservadas.Add(new Tuple<string, string, string>("#", "CE03", "Esp"));
            PalabrasReservadas.Add(new Tuple<string, string, string>("(", "CE04", "Esp"));
            PalabrasReservadas.Add(new Tuple<string, string, string>(")", "CE05", "Esp"));
            PalabrasReservadas.Add(new Tuple<string, string, string>("{", "CE06", "Esp"));
            PalabrasReservadas.Add(new Tuple<string, string, string>("}", "CE07", "Esp"));

            PalabrasReservadas.Add(new Tuple<string, string, string>("=", "ASIGN01", "Asi"));

            //Cometario
            PalabrasReservadas.Add(new Tuple<string, string, string>("Comentario", "COM", "Com"));
        }
        int Ide = 0;
        int errorLex = 0;
        int comment = 0;
        public string Lexico(string word, string last, int numLinea)
        {
            if (word == "")
            {
                return " ";
            }
            if (word[0] == '/')
            {
                comment++;
                return $"COM{comment} ";
            }
            //Cualquier Palabra reservada registrada
            if (PalabrasReservadas.Any(m => m.Item1 == word))
            {
                string find = PalabrasReservadas.FirstOrDefault(m => m.Item1 == word).Item2;
                return find + " ";
            }
            //Revisar si es una asignacion
            else if (PalabrasReservadas.Any(m => m.Item1 == last))
            {
                //revisa que tipo es
                if ("Type" == PalabrasReservadas.FirstOrDefault(m => m.Item1 == last).Item3)
                {
                    Ide++;
                    dtgIdes.Rows.Add($"IDE{Ide}", word, last);
                    return "IDE" + Ide + " ";
                }
                //Contenido
                else if (last == "=" || "Ope" == PalabrasReservadas.FirstOrDefault(m => m.Item1 == last).Item3 || "Rel" == PalabrasReservadas.FirstOrDefault(m => m.Item1 == last).Item3 || "Log" == PalabrasReservadas.FirstOrDefault(m => m.Item1 == last).Item3 || last == "(")
                {
                    foreach (var tipo in PalabrasReservadas)
                    {
                        if (tipo.Item3 is "Type")
                        {
                            if (Semantica(tipo.Item1, word, false, false) != "false")
                            {
                                return Semantica(tipo.Item1, word, false, true) + " ";
                            }
                        }
                    }
                }
            }
            //Otras situaciones
            if (isVariable(word) != "false")
            {
                //Escribe IDES ya creeados
                return isVariable(word);

            }
            errorLex++;
            dtgError.Rows.Add("Lexico", numLinea, "Palabra mal escrita");
            return $"LEXERR{errorLex} ";
        }

        private void Sintactico(string lineaStr, int numLinea)
        {
            string[] linea = lineaStr.Split();
            string any = string.Empty;
            _ = linea[0].Contains("IDE") ? any = "IDE"
                : _ = PalabrasReservadas.Any(m => m.Item2 == linea[0]) ? any = PalabrasReservadas.FirstOrDefault(m => m.Item2 == linea[0]).Item3 : _ = "yO";



            // ___ ___  __ __    ___  ____  ______    ___       ____      ___ ___   ____  ____   ____   ____      ____   ____     ___  ____   ___     ____ 
            //|   |   ||  |  |  /  _]|    \|      |  /  _]     /    |    |   |   | /    ||    \ |    | /    |    |    \ |    \   /  _]|    \ |   \   /    |
            //| _   _ ||  |  | /  [_ |  D  )      | /  [_     |  o  |    | _   _ ||  o  ||  D  ) |  | |  o  |    |  o  )|  D  ) /  [_ |  _  ||    \ |  o  |
            //|  \_/  ||  |  ||    _]|    /|_|  |_||    _]    |     |    |  \_/  ||     ||    /  |  | |     |    |     ||    / |    _]|  |  ||  D  ||     |
            //|   |   ||  :  ||   [_ |    \  |  |  |   [_     |  _  |    |   |   ||  _  ||    \  |  | |  _  |    |  O  ||    \ |   [_ |  |  ||     ||  _  |
            //|   |   ||     ||     ||  .  \ |  |  |     |    |  |  |    |   |   ||  |  ||  .  \ |  | |  |  |    |     ||  .  \|     ||  |  ||     ||  |  |
            //|___|___| \__,_||_____||__|\_| |__|  |_____|    |__|__|    |___|___||__|__||__|\_||____||__|__|    |_____||__|\_||_____||__|__||_____||__|__|

            switch (any)
            {
                //Asignacion
                case "Other":

                    break;
                case "Esp":

                    break;
                case "AniElse":

                    break;
                case "Type":
                    if (!(linea[1].Contains("IDE") && linea[2] == "ASIGN01" && (linea[3].Contains("IDE") || linea[3] == "CNR" || linea[3] == "CNE" || linea[3] == "BOOL" || linea[3] == "CADENA" || linea[3] == "CHAR")))
                    {
                        MessageBox.Show($"Error de sintaxix en la linea {numLinea}");
                        txtIDS.Select(txtIDS.Text.IndexOf(lineaStr), lineaStr.Length);
                        txtIDS.SelectionColor = Color.Red;
                        dtgError.Rows.Add("Sintactico", numLinea, "Asignacion mal hecha");
                    }
                    break;
                //Reasignacion
                case "IDE":
                    if (!(linea[1] == "ASIGN01" && (linea[2].Contains("IDE") || linea[2] == "CNR" || linea[2] == "CNE" || linea[2] == "BOOL" || linea[2] == "CADENA" || linea[2] == "CHAR")))
                    {
                        MessageBox.Show($"Error de sintaxix en la linea {numLinea}");
                        txtIDS.Select(txtIDS.Text.IndexOf(lineaStr), lineaStr.Length);
                        txtIDS.SelectionColor = Color.Red;
                        dtgError.Rows.Add("Sintactico", numLinea, "Reasignacion mal hecha");
                    }
                    break;
                //If,While
                case "Ani":
                    if (!(linea[1] == "CE04" && AnalizarIf(linea) && linea[linea.Length - 2] == "CE05"))
                    {
                        MessageBox.Show($"Error de sintaxix en la linea {numLinea}");
                        txtIDS.Select(txtIDS.Text.IndexOf(lineaStr), lineaStr.Length);
                        txtIDS.SelectionColor = Color.Red;
                        dtgError.Rows.Add("Sintactico", numLinea, "Condicional mal hecha");
                    }
                    break;
                case "Com":
                    break;
                //For
                case "AniFor":
                    if (!(linea[1] == "CE04" && AnalizarFor(linea) && linea[linea.Length - 2] == "CE05"))
                    {
                        MessageBox.Show($"Error de sintaxix en la linea {numLinea}");
                        txtIDS.Select(txtIDS.Text.IndexOf(lineaStr), lineaStr.Length);
                        txtIDS.SelectionColor = Color.Red;
                        dtgError.Rows.Add("Sintactico", numLinea, "For Loo mal hechó");
                    }
                    break;
                default:
                    MessageBox.Show($"Error de sintaxix en la linea {numLinea}");
                    txtIDS.Select(txtIDS.Text.IndexOf(lineaStr), lineaStr.Length);
                    txtIDS.SelectionColor = Color.Red;
                    dtgError.Rows.Add("Sintactico", numLinea, "Instruccion mal estructurada");
                    break;
            }
        }

        private string Semantica(string tipo, string valor, bool showError, bool rtnToken)
        {
            // Verificar tipo de dato
            switch (tipo)
            {
                case "int":
                    int numero;
                    if (!int.TryParse(valor, out numero))
                    {
                        if (showError)
                            MessageBox.Show("El valor asignado no es un numérico entero");
                        return "false";
                    }
                    else if (rtnToken)
                        return "CNE";
                    return "int";
                case "double":
                    double numerod;
                    if (!double.TryParse(valor, out numerod))
                    {
                        if (showError)
                            MessageBox.Show("El valor asignado no es un numérico real");
                        return "false";
                    }
                    else if (rtnToken)
                        return "CNR";
                    return "double";
                case "bool":
                    if (!(valor.ToLower() == "true" || valor.ToLower() == "false"))
                    {
                        if (showError)
                            MessageBox.Show("El valor asignado no es booleano");
                        return "false";
                    }
                    else if (rtnToken)
                        return "BOOL";
                    return "bool";
                case "char":
                    if (valor.Length != 3 || valor[0] != '\'')
                    {
                        if (showError)
                            MessageBox.Show("El valor asignado no es un caracter");
                        return "false";
                    }
                    else if (rtnToken)
                        return "CHAR";
                    return "char";
                case "string":
                    if (!(valor[0] == '\"' && valor[valor.Length - 1] == '\"'))
                    {
                        if (showError)
                            MessageBox.Show("El valor asignado no es una cadena");
                        return "false";
                    }
                    else if (rtnToken)
                        return "CADENA";
                    return "string";
                default:
                    break;
            }
            return "false";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dtgIdes.Rows.Clear();
            dtgError.Rows.Clear();

            int numLinea = 0;

            Ide = 0;
            errorLex = 0;
            comment = 0;

            txtIDS.Clear();
            //Lexico
            string lastword = "Text";
            foreach (var linea in txtFuente.Lines)
            {
                string line = QuitarEspacios(linea);
                numLinea++;
                foreach (var word in line.Split())
                {
                    string result = Lexico(word.ToString(), lastword, numLinea);
                    txtIDS.AppendText(result);
                    lastword = word;
                }
                txtIDS.AppendText("\n");
            }
            numLinea = 0;
            //Sintactico
            foreach (var line in txtIDS.Lines)
            {
                if (line == "" || line.Split()[0].Contains("COM")) continue;
                numLinea++;
                Sintactico(line, numLinea);
            }

        }

        public string QuitarEspacios(string input)
        {
            return Regex.Replace(input, @"\s+", " ").TrimEnd();
        }




        //__/\\\\\\\\\\\\\_________/\\\\\_______/\\\\\\\\\\\\\\\__/\\\\\\\\\\\\\\\_______/\\\\\_______/\\\\____________/\\\\____________/\\\________/\\\__/\\\\\\\\\\\\\___
        //_\/\\\/////////\\\_____/\\\///\\\____\///////\\\/////__\///////\\\/////______/\\\///\\\____\/\\\\\\________/\\\\\\___________\/\\\_______\/\\\_\/\\\/////////\\\_       
        //  _\/\\\_______\/\\\___/\\\/__\///\\\________\/\\\_____________\/\\\_________/\\\/__\///\\\__\/\\\//\\\____/\\\//\\\___________\/\\\_______\/\\\_\/\\\_______\/\\\_      
        //   _\/\\\\\\\\\\\\\\___/\\\______\//\\\_______\/\\\_____________\/\\\________/\\\______\//\\\_\/\\\\///\\\/\\\/_\/\\\___________\/\\\_______\/\\\_\/\\\\\\\\\\\\\/__     
        //    _\/\\\/////////\\\_\/\\\_______\/\\\_______\/\\\_____________\/\\\_______\/\\\_______\/\\\_\/\\\__\///\\\/___\/\\\___________\/\\\_______\/\\\_\/\\\/////////____    
        //     _\/\\\_______\/\\\_\//\\\______/\\\________\/\\\_____________\/\\\_______\//\\\______/\\\__\/\\\____\///_____\/\\\___________\/\\\_______\/\\\_\/\\\_____________   
        //      _\/\\\_______\/\\\__\///\\\__/\\\__________\/\\\_____________\/\\\________\///\\\__/\\\____\/\\\_____________\/\\\___________\//\\\______/\\\__\/\\\_____________  
        //       _\/\\\\\\\\\\\\\/_____\///\\\\\/___________\/\\\_____________\/\\\__________\///\\\\\/_____\/\\\_____________\/\\\____________\///\\\\\\\\\/___\/\\\_____________ 
        //        _\/////////////_________\/////_____________\///______________\///_____________\/////_______\///______________\///_______________\/////////_____\///______________



        public static void RevisarSegundaPasadaBottomUp(string[] palabras)
        {
            // Crear una matriz para almacenar los resultados de la primera pasada
            int[,] resultados = new int[palabras.Length, palabras.Length];

            // Realizar la primera pasada
            for (int i = 0; i < palabras.Length; i++)
            {
                for (int j = 0; j < palabras.Length; j++)
                {
                    if (i == j)
                    {
                        resultados[i, j] = palabras[i].Length;
                    }
                    else
                    {
                        int longitudComun = LongitudComunMasLarga(palabras[i], palabras[j]);
                        resultados[i, j] = palabras[i].Length - longitudComun;
                    }
                }
            }

            // Realizar la segunda pasada utilizando el método bottom-up
            for (int k = 0; k < palabras.Length; k++)
            {
                for (int i = 0; i < palabras.Length; i++)
                {
                    for (int j = 0; j < palabras.Length; j++)
                    {
                        int nuevaLongitud = resultados[i, k] + resultados[k, j];
                        if (nuevaLongitud < resultados[i, j])
                        {
                            resultados[i, j] = nuevaLongitud;
                        }
                    }
                }
            }

            // Imprimir los resultados de la segunda pasada
            Console.WriteLine("Resultados de la segunda pasada:");
            for (int i = 0; i < palabras.Length; i++)
            {
                for (int j = 0; j < palabras.Length; j++)
                {
                    Console.Write(resultados[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        public static int LongitudComunMasLarga(string palabra1, string palabra2)
        {
            int[,] longitudComun = new int[palabra1.Length + 1, palabra2.Length + 1];
            int maxLongitud = 0;
            for (int i = 0; i <= palabra1.Length; i++)
            {
                for (int j = 0; j <= palabra2.Length; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        longitudComun[i, j] = 0;
                    }
                    else if (palabra1[i - 1] == palabra2[j - 1])
                    {
                        longitudComun[i, j] = longitudComun[i - 1, j - 1] + 1;
                        maxLongitud = Math.Max(maxLongitud, longitudComun[i, j]);
                    }
                    else
                    {
                        longitudComun[i, j] = 0;
                    }
                }
            }
            return maxLongitud;
        }



        public bool AnalizarIf(string[] Expresion)
        {
            string[] elementos = new string[Expresion.Length - 4];
            Array.Copy(Expresion, 2, elementos, 0, Expresion.Length - 4);

            if (elementos.Length <= 2)
            {
                return false;
            }
            int bloques = 0;
            foreach (var item in elementos)
            {
                bloques++;
                switch (bloques)
                {
                    case 1:
                        if (!(item.Contains("IDE") || item == "CNR" || item == "CNE" || item == "BOOL" || item == "CADENA" || item == "CHAR"))
                        {
                            return false;
                        }
                        break;
                    case 2:
                        if (PalabrasReservadas.Any(m => m.Item2 == item))
                        {
                            if (PalabrasReservadas.FirstOrDefault(m => m.Item2 == item).Item3 != "Rel")
                            {
                                return false;
                            }
                        }
                        break;
                    case 3:
                        if (!(item.Contains("IDE") || item == "CNR" || item == "CNE" || item == "BOOL" || item == "CADENA" || item == "CHAR"))
                        {
                            return false;
                        }
                        break;
                    case 4:
                        bloques = 0;
                        if (PalabrasReservadas.Any(m => m.Item2 == item))
                        {
                            if (PalabrasReservadas.FirstOrDefault(m => m.Item2 == item).Item3 != "Log")
                            {
                                return false;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            return true;
        }

        public bool AnalizarFor(string[] Expresion)
        {
            string[] elementos = new string[Expresion.Length - 4];
            Array.Copy(Expresion, 2, elementos, 0, Expresion.Length - 4);

            if (PalabrasReservadas.Any(m => m.Item2 == elementos[0]))
            {
                if (PalabrasReservadas.FirstOrDefault(m => m.Item2 == elementos[0]).Item1 != "int")
                {
                    return false;
                }
            }
            if (!elementos[1].Contains("IDE"))
            {
                return false;
            }
            if (elementos[2] != "ASIGN01")
            {
                return false;
            }
            if (elementos[3] != "CNE")
            {
                return false;
            }
            if (!elementos[4].Contains("IDE"))
            {
                return false;
            }
            if (PalabrasReservadas.Any(m => m.Item2 == elementos[5]))
            {
                if (PalabrasReservadas.FirstOrDefault(m => m.Item2 == elementos[5]).Item3 != "Rel")
                {
                    return false;
                }
            }
            if (elementos[6] != "CNE")
            {
                return false;
            }
            if (!elementos[7].Contains("IDE"))
            {
                return false;
            }
            if (elementos[8] != "OPER1" || elementos[9] != "OPER1")
            {
                return false;
            }
            return true;
        }

        public string isVariable(string word)
        {
            foreach (DataGridViewRow item in dtgIdes.Rows)
            {
                if (Convert.ToString(item.Cells[1].Value) == word)
                {
                    return item.Cells[0].Value.ToString() + " ";
                }
            }
            return "false";
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            // Crear un objeto OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Establecer los filtros de archivo y las opciones del cuadro de diálogo
            openFileDialog.Filter = "Archivos de texto (*.xd)|*.xd";
            openFileDialog.Title = "Seleccionar archivo de texto";
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;

            // Mostrar el cuadro de diálogo
            DialogResult result = openFileDialog.ShowDialog();

            // Si el usuario hace clic en "Abrir"
            if (result == DialogResult.OK)
            {
                try
                {
                    // Leer todo el contenido del archivo
                    string contenidoArchivo = File.ReadAllText(openFileDialog.FileName);

                    txtFuente.Text = contenidoArchivo;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al abrir el archivo: {ex.Message}");
                }
            }
        }
    }
}