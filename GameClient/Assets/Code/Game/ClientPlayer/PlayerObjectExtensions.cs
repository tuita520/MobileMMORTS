﻿using Client.Net;
using MapHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Code.Game.ClientPlayer
{
    public static class PlayerObjectExtensions
    {
        public static void TeleportToTile(this PlayerWrapper player, int x,  int y)
        {
            UnityClient.Map.EntityPositions.RemoveEntity(player, player.Position);
            player.PlayerObject.transform.position = new Vector2(x * 16, -y * 16);
            UnityClient.Player.Position.X = x;
            UnityClient.Player.Position.Y = y;
            UnityClient.Map.EntityPositions.AddEntity(player, player.Position);
            
        }

        public static bool FindPathTo(this PlayerWrapper player, Position position)
        {
            var path =UnityClient.Map.FindPath(player.Position, position);
            if (path != null)
            {
                player.FollowingPath = path;
            }
            return path != null;
        }
    }
}
