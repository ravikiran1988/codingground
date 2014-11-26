open System.Threading

let doubler = MailboxProcessor.Start(fun(inbox: obj MailboxProcessor) ->
    async{
        let rec act() =
            let message = Async.RunSynchronously(inbox.Receive())
            match message with
            | :? string as msg -> printfn "You gave a %s" msg
            | :? int as value -> printfn "Double of value is %d" (value*2)
            act()
        act()
    }
)
printfn  "In Main %d" Thread.CurrentThread.ManagedThreadId
[1;2;3;4;5] |> List.iter(fun e -> doubler.Post(e))
doubler.Post("Hello")
Thread.Sleep(2000)
