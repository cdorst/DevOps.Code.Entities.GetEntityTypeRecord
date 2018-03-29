// Copyright © Christopher Dorst. All rights reserved.
// Licensed under the GNU General Public License, Version 3.0. See the LICENSE document in the repository root for license information.

using DevOps.Code.Entities.EntityTypeLedger;
using Microsoft.WindowsAzure.Storage.Table;
using System.Threading.Tasks;
using static DevOps.Code.Entities.GetAzureTable.AzureTableGetter;

namespace DevOps.Code.Entities.GetEntityTypeRecord
{
    /// <summary>Function gets the given entity-type's ID record from the Azure Storage Table entity-types ledger</summary>
    public static class EntityTypeRecordGetter
    {
        /// <summary>Returns the given entity-type's ID record from the Azure Storage Table entity-types ledger</summary>
        public static async Task<EntityTypeTable> GetEntityTypeRecordAsync(string accountName, string repositoryName)
        {
            var operation = TableOperation.Retrieve<EntityTypeTable>(accountName, repositoryName);
            var table = await GetTable();
            var result = await table.ExecuteAsync(operation);
            if (result?.Result == null) return null;
            return (EntityTypeTable)result.Result;
        }
    }
}
