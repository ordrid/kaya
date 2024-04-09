module Kaya.Tests

open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.TestHost

open Swensen.Unquote
open Xunit

[<Fact>]
let ``My test`` () =
    let webHostBuilder = new WebHostBuilder() |> Kaya.configure
    let server = new TestServer(webHostBuilder)
    let client = server.CreateClient()

    let response =
        task {
            let! response = client.GetAsync "/"
            let! content = response.Content.ReadAsStringAsync()

            return content
        }
        |> Async.AwaitTask
        |> Async.RunSynchronously

    test <@ response = "Hello World from Giraffe!" @>
