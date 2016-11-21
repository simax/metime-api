#r "./packages/sqlprovider/lib/FSharp.Data.SQLProvider.dll"

open FSharp.Data.Sql

let [<Literal>] resolutionPath =  @"/Users/simonlomax/Documents/Development/sqlite" 
let [<Literal>] connectionString = "Data Source=" + __SOURCE_DIRECTORY__ + @"./data/metime.sqlite;Version=3"
 
// create a type alias with the connection string and database vendor settings
type sql = SqlDataProvider< 
              ConnectionString = connectionString,
              DatabaseVendor = Common.DatabaseProviderTypes.SQLITE,
              ResolutionPath = resolutionPath>
let ctx = sql.GetDataContext()

