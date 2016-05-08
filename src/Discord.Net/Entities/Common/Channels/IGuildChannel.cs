﻿using Discord.API.Rest;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Discord
{
    public interface IGuildChannel : IChannel, IDeletable, IUpdateable
    {
        /// <summary> Gets the name of this channel. </summary>
        string Name { get; }
        /// <summary> Gets the position of this channel in the guild's channel list, relative to others of the same type. </summary>
        int Position { get; }

        /// <summary> Gets the guild this channel is a member of. </summary>
        IGuild Guild { get; }

        /// <summary> Creates a new invite to this channel. </summary>
        /// <param name="maxAge"> The time (in seconds) until the invite expires. Set to null to never expire. </param>
        /// <param name="maxUses"> The max amount  of times this invite may be used. Set to null to have unlimited uses. </param>
        /// <param name="isTemporary"> If true, a user accepting this invite will be kicked from the guild after closing their client. </param>
        /// <param name="withXkcd"> If true, creates a human-readable link. Not supported if maxAge is set to null. </param>
        Task<IGuildInvite> CreateInvite(int? maxAge = 1800, int? maxUses = default(int?), bool isTemporary = false, bool withXkcd = false);
        /// <summary> Returns a collection of all invites to this channel. </summary>
        Task<IEnumerable<IGuildInvite>> GetInvites();

        /// <summary> Gets a collection of permission overwrites for this channel. </summary>
        IReadOnlyDictionary<ulong, Overwrite> PermissionOverwrites { get; }

        /// <summary> Modifies this guild channel. </summary>
        Task Modify(Action<ModifyGuildChannelParams> func);

        /// <summary> Gets the permission overwrite for a specific role, or null if one does not exist. </summary>
        OverwritePermissions? GetPermissionOverwrite(IRole role);
        /// <summary> Gets the permission overwrite for a specific user, or null if one does not exist. </summary>
        OverwritePermissions? GetPermissionOverwrite(IUser user);
        /// <summary> Removes the permission overwrite for the given role, if one exists. </summary>
        Task RemovePermissionOverwrite(IRole role);
        /// <summary> Removes the permission overwrite for the given user, if one exists. </summary>
        Task RemovePermissionOverwrite(IUser user);
        /// <summary> Adds or updates the permission overwrite for the given role. </summary>
        Task AddPermissionOverwrite(IRole role, OverwritePermissions permissions);
        /// <summary> Adds or updates the permission overwrite for the given user. </summary>
        Task AddPermissionOverwrite(IUser user, OverwritePermissions permissions);

        /// <summary> Gets a collection of all users in this channel. </summary>
        new Task<IEnumerable<IGuildUser>> GetUsers();
        /// <summary> Gets a user in this channel with the provided id.</summary>
        new Task<IGuildUser> GetUser(ulong id);
    }
}