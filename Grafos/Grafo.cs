using System;
using System.Collections.Generic;
using System.Text;

namespace Grafos
{
    class Grafo
    {
        public class Vertice
        {
            public int vid { get; set; }
            private SortedDictionary<int, int> proximos = new SortedDictionary<int, int>(); // v2, custo
            private SortedDictionary<int, int> anteriores = new SortedDictionary<int, int>();

            public Vertice(int vid = 0)
            {
                this.vid = vid;
            }

            public void addProximo(int v2, int custo = 0)
            {
                proximos.Add(v2, custo);
            }

            public void addAnterior(int v1, int custo = 0)
            {
                anteriores.Add(v1, custo);
            }

            public void removeAnt (int id)
            {
                if (anteriores.ContainsKey(id))
                    anteriores.Remove(id);
            }

            public void removeProx(int id)
            {
                if (proximos.ContainsKey(id))
                    proximos.Remove(id);
            }

            public void removeAdj (int id)
            {
                removeAnt(id);
                removeProx(id);
            }

            public SortedDictionary<int, int> GetAdjacentes()
            {
                var temp = new SortedDictionary<int, int>();
                foreach (var v in proximos)
                {
                    temp.TryAdd(v.Key, v.Value);
                }
                foreach (var v in anteriores)
                {
                    temp.TryAdd(v.Key, v.Value);
                }
                return temp;
            }

            public SortedDictionary<int,int> GetProximos()
            {
                return proximos;
            }
        }

        static Random r = new Random();
        private SortedDictionary<int, Vertice> Verticess;

        public Grafo()
        {
            Verticess = new SortedDictionary<int, Vertice>();
            Verticess.Clear();
        }

        public void AddVertice(int id)
        {
            Vertice v = new Vertice(id);
            Verticess.Add(id, v);
        }

        public void RemoveVertice(int id)
        {
            if (Verticess.ContainsKey(id))
            {
                foreach (var v in Verticess.GetValueOrDefault(id).GetAdjacentes())
                {
                    Desconecta(v.Key, id);
                }
                Verticess.Remove(id);
            }
        }

        public void Conecta(int id1, int id2, int c = 0)
        {
            ConectaOrdenado(id1, id2, c);
            ConectaOrdenado(id2, id1, c);
        }

        public void ConectaOrdenado(int id1, int id2, int c = 0)
        {
            if (Verticess.ContainsKey(id2) && Verticess.ContainsKey(id1))
            {
                Verticess.GetValueOrDefault(id1).addProximo(id2, c);
                Verticess.GetValueOrDefault(id2).addAnterior(id1, c);
            }
        }

        public void Desconecta(int id1, int id2)
        {
            DesconectaOrdenado(id1, id2);
            DesconectaOrdenado(id2, id1);
        }

        public void DesconectaOrdenado(int id1, int id2)
        {
            if (Verticess.ContainsKey(id1) && Verticess.ContainsKey(id2))
            {
                if (Verticess.GetValueOrDefault(id1).GetAdjacentes().ContainsKey(id2))
                {
                    Verticess.GetValueOrDefault(id1).removeAdj(id2);
                }
            }
        }

        public int Ordem ()
        {
            return Verticess.Count;
        }

        public SortedDictionary<int,Vertice> Vertices()
        {
            return Verticess;
        }

        public Vertice umVertice()
        {
            return Verticess.GetValueOrDefault(GetRandomKey());
        }

        private int GetRandomKey ()
        {
            int[] keys = new int[Verticess.Count];
            Verticess.Keys.CopyTo(array: keys, index: 0);
            return keys[r.Next(keys.Length)];
        }

        public SortedDictionary<int, int> Adjacentes(int vid)
        {
            if (!Verticess.ContainsKey(vid))
                return new SortedDictionary<int, int>();
            return Verticess.GetValueOrDefault(vid).GetAdjacentes();
        }

        public int Grau (int vid)
        {
            return Adjacentes(vid).Count;
        }

        public bool EhRegular()
        {
            int test = Grau(umVertice().vid);
            foreach (var v in Verticess)
            {
                if (Grau(v.Key) != test)
                    return false;
            }
            return true;
        }

        public bool EhCompleto()
        {
            foreach (var v in Verticess)
            {
                if (Grau(v.Key) != Verticess.Count)
                    return false;
            }
            return true;
        }

        public SortedSet<int> FechoTransitivo(int vid)
        {
            var Conj = new SortedSet<int>();
            ProcuraFechoTransitivo(vid, Conj);
            return Conj;
        }

        private SortedSet<int> ProcuraFechoTransitivo(int vid, SortedSet<int> Conj)
        {
            Conj.Add(vid);
            foreach (var v in Verticess.GetValueOrDefault(vid).GetAdjacentes())
            {
                if (!Conj.Contains(v.Key))
                    Conj.UnionWith(ProcuraFechoTransitivo(v.Key, Conj));
            }
            return Conj;
        }

        public bool EhConexo()
        {
            var Conj = new SortedSet<int>();
            foreach (var v in Verticess)
            {
                Conj.Add(v.Key);
            }

            return Conj.SetEquals(FechoTransitivo(umVertice().vid));
        }

        public bool EhArvore()
        {
            var vis = new HashSet<int>();
            return EhConexo() && !HaCiclo(umVertice().vid, umVertice().vid,vis);
        }

        private bool HaCiclo(int id, int idAnt, HashSet<int> visitados)
        {
            if (visitados.Contains(id))
                return true;
            visitados.Add(id);
            foreach (var v in Verticess.GetValueOrDefault(id).GetAdjacentes())
            {
                if (!v.Key.Equals(idAnt))
                    if (HaCiclo(v.Key, id, visitados))
                        return true;
            }
            visitados.Remove(id);
            return false;
        }
        
        public List<int> OrdenacaoTopologica ()
        {
            List<int> topo = new List<int>();
            Dictionary<int,bool> mark = new Dictionary<int,bool>();
            int temp = GetRandomKey();

            while (Verticess.Count != mark.Count)
            {
                while (mark.ContainsKey(temp))
                    temp = GetRandomKey();
                VisitaTopologica(temp, topo, mark);
            }
            topo.Reverse();
            return topo;
        }

        private void VisitaTopologica (int n, List<int> topo, Dictionary<int,bool> mark)
        {
            if (mark.ContainsKey(n) && mark.GetValueOrDefault(n) == true)
                return;
            if (mark.ContainsKey(n) && mark.GetValueOrDefault(n) == false)
            {
                System.Console.WriteLine("Erro, Grafo Nao é DAG");
                System.Console.ReadKey();
                Environment.Exit(10);
            }
            mark.Add(n, false);
            foreach (var v in Verticess.GetValueOrDefault(n).GetProximos())
            {
                VisitaTopologica(v.Key, topo, mark);
            }
            mark.Remove(n);
            mark.Add(n, true);
            topo.Add(n);
        }
    }
}