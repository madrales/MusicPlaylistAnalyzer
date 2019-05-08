using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MusicPlaylistAnalyzer
{
    public class musicReport
    {
        public static string GenerateText(List<musicCategories> musicCategoriesList) 
        {
            string report = "Music Playlist Analyzer\n\n";

            if (musicCategoriesList.Count() < 1)
            {
                report += "No data is available.\n";

                return report;
            }

            report += "Songs with 200 plays or more: ";
            var twoHundredorMore = from musicCategories in musicCategoriesList where musicCategories.Plays >= 200 select musicCategories;

            foreach (var song in twoHundredorMore)
            {
                report += song + ", ";
            }
            report += "\n\n";
            report += "Songs from the Alternative Genre: ";

            var altSongs = from musicCategories in musicCategoriesList where musicCategories.Genre == "Alternative" select musicCategories;
            var AltSongs = 0;
            foreach (var song in altSongs)
            {
                AltSongs += 1;
            }
            report += AltSongs;

            report += "\n\n";
            report += "Songs from the Hip-Hop or Rap Genre: ";

            var hiphopRapSongs = from musicCategories in musicCategoriesList where musicCategories.Genre == "Hip-Hop/Rap" select musicCategories;
            var HipHopRap = 0;

            foreach (var rap in hiphopRapSongs)
            {
                HipHopRap += 1;
            }

            report += HipHopRap;

            report += "\n";

            report += "\n\n";
            report += "Songs from the album, 'Welcome to the Fishbowl': ";

            var welcometoFishBowl = from musicCategories in musicCategoriesList where musicCategories.Album == "Welcome to the Fishbowl" select musicCategories;

            foreach (var fish in welcometoFishBowl)
            {
                report += fish;
            }

            report += "\n\n";
            report += "Songs from before 1970: ";

            var songsFrom1970 = from musicCategories in musicCategoriesList where musicCategories.Year <= 1970 select musicCategories;

            foreach (var song1970 in songsFrom1970)
            {
                report += song1970;
            }

            report += "\n\n";
            report += "Song names longer than 85 characters: ";

            var songsLongerThan85 = from musicCategories in musicCategoriesList where musicCategories.Name.Length > 85 select musicCategories;

            foreach (var song in songsLongerThan85)
            {
                report += song.Name;
            }

            report += "\n\n";
            report += "Longest song (duration): ";

            var longestSong = (from musicCategories in musicCategoriesList select musicCategories.Time).Max();

            report += longestSong;

            return report;
            
        }
    }
}
