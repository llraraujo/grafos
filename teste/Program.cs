namespace teste
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            var grafo = new Dictionary<string, string>();

            var idsArmazem = new HashSet<int>() { 2, 4 };

            object[][] grid = 
            [
                [1, 1, "estrada", 2, 2],

                [1, "estrada", "estrada", "estrada", 2],

                ["estrada", "estrada", "estrada", "estrada", ""],

                [3, "estrada", "", "estrada", 4],

                [3, 3, "estrada", 4, 4]
            ];

            int linhas = grid.Length;
            int colunas = grid[0].Length;

            for (int i = 0; i < linhas; i++) 
            {    
                for(int j = 0; j < colunas; j++)
                {                   
                    PercorrerGridEAdicionaElementos(i, j);
                }
            }

            foreach ((string key, string value) in grafo)
            {
                Console.WriteLine($"{key} -- {value}");
            }


            void PercorrerGridEAdicionaElementos(int linha, int coluna)
            {
                var noParaVisitar = new List<int>() { linha, coluna };
                var visitados = new List<int[]>();                

                var indicesOrtogonais = new List<Tuple<int, int>>()
                {
                    Tuple.Create(-1, 0),
                    Tuple.Create(1, 0),
                    Tuple.Create(0, -1),
                    Tuple.Create(0, 1),
                };

                for (int i = 0; i < noParaVisitar.Count; i++)
                {
                   
                    int x, y;
                    x = noParaVisitar[0]; 
                    y = noParaVisitar[1]; 

                    var elementoAtual = grid[x][y];
                    noParaVisitar.Clear();

                    foreach ((int dx, int dy) in indicesOrtogonais)
                    {
                        int nx = x + dx;
                        int ny = y + dy;
                        if ( (0 <= nx && nx < linhas)
                          && (0 <= ny && ny < colunas)
                          && (!visitados.Contains([nx, ny])))
                        {
                            
                            if (grid[nx][ny].ToString() == "estrada") 
                            {
                                int larguraEstrada = 1;
                                if(dx != 0)
                                {
                                    larguraEstrada = grid.Select(row => row[y].ToString() == "estrada").Count();
                                }
                                else
                                {
                                    larguraEstrada = grid[x].Count(e => e.ToString() == "estrada");
                                }

                                bool isIntersection = indicesOrtogonais.Any(dir =>
                                {
                                    int ix = nx + dir.Item1;
                                    int iy = ny + dir.Item2;
                                    return (0 <= ix && ix < linhas && 0 <= iy && iy < colunas && grid[ix][iy].ToString() == "estrada");
                                });

                                if (isIntersection)
                                {
                                    grafo[$"({nx},{ny})"] = $"Interseção de estrada";
                                }
                                else
                                {
                                    grafo[$"({nx},{ny})"] = $"Estrada. Peso={larguraEstrada}";
                                }

                                noParaVisitar.AddRange([nx, ny]);
                                visitados.Add([nx, ny]);
                            }
                            else if (string.IsNullOrEmpty(grid[nx][ny].ToString()))
                            {
                                grafo[$"({nx},{ny})"] = $"Terminacao de estrada";
                            }
                            else if(grid[nx][ny].GetType() == typeof(int))
                            {
                                int armazem = idsArmazem.FirstOrDefault(e => e == (int) grid[nx][ny]);
                                if(armazem != default)
                                {
                                    grafo[$"({nx},{ny})"] = $"Armazem: {grid[nx][ny]}";
                                }
                                else
                                {
                                    grafo[$"({nx},{ny})"] = $"Predio: {grid[nx][ny]}";
                                }                                
                            }
                        }                        
                    }
                }
            }                             
        }       
    }
}
