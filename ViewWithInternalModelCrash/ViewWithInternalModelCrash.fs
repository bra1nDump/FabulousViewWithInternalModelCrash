// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace ViewWithInternalModelCrash

open System.Diagnostics
open Fabulous
open Fabulous.XamarinForms
open Fabulous.XamarinForms.LiveUpdate
open Xamarin.Forms

module App = 
    let init () = (), Cmd.none

    let update (_: unit) _ = (), Cmd.none

    let view (_: unit) _ =
        View.ContentPage(
            content = 
                View.WithInternalModel(
                    init = fun () -> ()
                    , update = fun _ _ -> ()
                    , view = fun _ _ -> View.BoxView()
                )
        )

    // Note, this declaration is needed if you enable LiveUpdate
    let program = Program.mkProgram init update view

type App () as app = 
    inherit Application ()

    let runner = 
        App.program
#if DEBUG
        |> Program.withConsoleTrace
#endif
        |> XamarinFormsProgram.run app
