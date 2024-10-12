using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicativoMaiu
{
    public class SpotifyService
    {
        public async Task OpenSpotifyPlaylist(string playlistId)
        {
            // Monta a URI para a playlist no Spotify
            var spotifyUri = $"spotify:playlist:{playlistId}";

            // Abre a playlist no aplicativo Spotify ou no navegador
            await Launcher.OpenAsync(spotifyUri);

         
        }
    }
}