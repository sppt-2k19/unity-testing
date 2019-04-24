namespace Assembly_FSharp
open UnityEngine

type Player() =
    inherit MonoBehaviour()    

    member this.Start() =
        let startupMessage = "Printed on start"
        Debug.Log(startupMessage)
        
    member this.Update() =
        let startupMessage = "Printed on every update"
        ()

