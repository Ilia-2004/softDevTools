﻿using System;

namespace AdjacencyList
{
  internal abstract class Program
  { 
    public static void Main() 
    {
      var objectGraph = new Graph();
      const string pathFile = @"F:\Ilya\Programming\Esin\AdjacencyList\test-files\";
        
      while (true)
      { 
        Console.WriteLine("GRAPH ADJACENCY LIST");
        Console.WriteLine(" $ what do you want to do? | if you need help input '--h'");
        Console.Write("  > "); var command = Console.ReadLine();
        
        if (command == "--h")
        {
          Console.WriteLine(" $ output an adjacency list,           '--out-list'");
          Console.WriteLine(" $ add a graph vertex,                 '--add-vert'");
          Console.WriteLine(" $ add a graph edge,                   '--add-edge'");
          Console.WriteLine(" $ remove a graph vertex,              '--rem-vert'");
          Console.WriteLine(" $ remove a graph edge,                '--rem-edge'");
          Console.WriteLine(" $ add a graph from a file,            '--add-from-file'");
          Console.WriteLine(" $ input a matrix of adjacency list,   '--output-mat'");
          Console.WriteLine(" $ build a complete graph,             '--build-com-graph'");
          Console.WriteLine(" $ if you need help,                   '--h'");
          Console.WriteLine(" $ exit program,                       '--e'");
          Console.ReadKey();
          Console.Clear();
        }
        else if (command == "--out-list")
        {
           objectGraph.OutList();
           
           Console.ReadKey();
           Console.Clear();
        }
        else if (command == "--add-vert")
        {
          Console.WriteLine(" $ input your vertex:");
          Console.Write("  > "); var vertex = Console.ReadLine();
          
          var addVertex = objectGraph.AddVertex(vertex.ToUpper());
          Console.WriteLine(addVertex
            ? " $ your vertex has been successfully added"
            : " $ [ERROR]: you wrote an incorrect command!");

          Console.ReadKey();
          Console.Clear();
        }
        else if (command == "--add-edge")
        {
          string to;
          string from;
          int? weight = null; 
          bool isDirected;

          try
          {
            Console.WriteLine(" $ input your edge 'from':");
            Console.Write("  > "); from = Console.ReadLine();
            
            Console.WriteLine(" $ input your edge 'to':");
            Console.Write("  > "); to = Console.ReadLine();
            
            Console.WriteLine(" $ input your edge weight:");
            Console.Write("  > "); var value = Console.ReadLine();
            if (value != "0") weight = Convert.ToInt32(value); 
            
            Console.WriteLine(" $ input directed:");
            Console.Write("  > "); isDirected = Convert.ToBoolean(Console.ReadLine());
          }
          catch
          {
            Console.WriteLine(" $ [ERROR]: you wrote an incorrect dataset!");
            Console.ReadKey();
            Console.Clear();
            
            continue; 
          }
          
          var addEdge = objectGraph.AddEdge(from.ToUpper(), to.ToUpper(), weight, isDirected);
          Console.WriteLine(addEdge
            ? " $ your edge has been successfully added"
            : " $ [ERROR]: you wrote an incorrect command!");

          Console.ReadKey();
          Console.Clear();
        }
        else if (command == "--rem-vert")
        {
          Console.WriteLine(" $ input your vertex:");
          Console.Write("  > "); var vertex = Console.ReadLine();
          
          var remVert = objectGraph.RemoveVertex(vertex.ToUpper());
          Console.WriteLine(remVert
            ? " $ your vertex has been successfully removed"
            : " $ [ERROR]: you wrote an incorrect command!");

          Console.ReadKey();
          Console.Clear();
        }
        else if (command == "--rem-edge")
        {
          Console.WriteLine(" $ input your vertex 'from':");
          Console.Write("  > "); var from = Console.ReadLine();
          
          Console.WriteLine(" $ input your vertex 'to':");
          Console.Write("  > "); var to = Console.ReadLine();
          
          Console.WriteLine(" $ input directed:");
          Console.Write("  > "); var isDirected = Convert.ToBoolean(Console.ReadLine());
          
          var remEdge = objectGraph.RemoveEdge(from.ToUpper(), to.ToUpper(), isDirected);
          Console.WriteLine(remEdge
            ? " $ your edge has been successfully removed"
            : " $ [ERROR]: you wrote an incorrect command!");

          Console.ReadKey();
          Console.Clear();
        }
        else if (command == "--add-from-file")
        {
          Console.WriteLine(" $ input a name of file:");
          Console.Write("  > "); var nameFile = Console.ReadLine();

          var addFromFile = objectGraph.AddFromFile(pathFile + nameFile);
          Console.WriteLine(addFromFile
            ? " $ your edge has been successfully removed"
            : " $ [ERROR]: you wrote an incorrect command!");
          
          Console.ReadKey();
          Console.Clear();
        }
        else if (command == "--add-in-file")
        {
          Console.WriteLine(" $ input a name of file:");
          Console.Write("  > "); var nameFile = Console.ReadLine();

          var addInFile = objectGraph.AddInFile(pathFile + nameFile);
          Console.WriteLine(addInFile
            ? " $ your edge has been successfully removed"
            : " $ [ERROR]: you wrote an incorrect command!");

          Console.ReadKey();
          Console.Clear();
        }
        else if (command == "--output-mat")
        {
          objectGraph.OutputsAdjacencyMatrix();

          Console.ReadKey();
          Console.Clear();
        }
        else if (command == "--build-com-graph")
        {
          var objectMethod = Graph.BuildCompleteGraph(objectGraph);
          objectMethod.OutputsAdjacencyMatrix();
          
          Console.WriteLine(" $ the complete graph has been successfully constructed!");
          Console.ReadKey();
          Console.Clear();
        }
        else if (command == "--e") break;
        else
        {
          Console.WriteLine(" $ [ERROR]: you wrote an incorrect command!");
          Console.ReadKey();
          Console.Clear();
        }
      }
    }
  }
}