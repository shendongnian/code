        [LuisIntent("Cotizar")]
        public async Task CotizarAsync(IDialogContext context, IAwaitable<IMessageActivity> activity, LuisResult result)
        {
            context.Call(new FormDialog<Cotizacion>(new Cotizacion(), Cotizacion.BuildForm, FormOptions.PromptInStart, result.Entities), 
                ResumeAfterCallback);
        }
