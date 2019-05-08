using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicPlaylistAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program analyzes music playlists");

            if (args.Length != 2)
            {
                Console.WriteLine("Music Playlist Analyzer requires two files to be supplied. They should be the playlist to be analyzed and the report file respectively.");
                Environment.Exit(1);
            }

            //Create strings for the Input files
            string playlistFile = args[0];
            string reportFile = args[1];

            List<musicCategories> musicCategoriesList = null;
            try
            {
                musicCategoriesList = musicLoader.Load(playlistFile);
            }catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(2);
            }

            var report = musicReport.GenerateText(musicCategoriesList);

            try
            {
                System.IO.File.WriteAllText(reportFile, report);
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(3);
            }


        }
    }
}
