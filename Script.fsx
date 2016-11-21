#r "./packages/sqlprovider/lib/FSharp.Data.SQLProvider.dll"

open FSharp.Data.Sql

let [<Literal>] ResolutionPath =  @"/Users/simonlomax/Documents/Development/sqlite" 
let [<Literal>] ConnectionString = "Data Source=/Users/simonlomax/Documents/Development/fsharp-projects/metime-api/data/metime.sqlite;Version=3"
 
// create a type alias with the connection string and database vendor settings
type Sql = SqlDataProvider< 
              ConnectionString = ConnectionString,
              DatabaseVendor = Common.DatabaseProviderTypes.SQLITE,
              ResolutionPath = ResolutionPath,
              IndividualsAmount = 1000,
              UseOptionTypes = true>
let ctx = Sql.GetDataContext()

let emps = query { for e in ctx.Main.Employees do
                    select (e.Firstname, e.Lastname, e.Email) } 
            |> Seq.toArray

printfn "%A" emps




