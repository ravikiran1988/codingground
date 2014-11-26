open System.Threading
printfn "Main thread is %d" Thread.CurrentThread.ManagedThreadId
let block = async{
    printfn "In block %d" Thread.CurrentThread.ManagedThreadId
    return 6
}
let block2 = async{
    let! result = block
    printfn "%d" result
}
let result: int = Async.RunSynchronously block
Thread.Sleep(2000)
printfn "The value is %d" result