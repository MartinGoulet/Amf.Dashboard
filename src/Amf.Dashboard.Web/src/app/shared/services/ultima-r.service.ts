import { Injectable } from '@angular/core';
import { IPanierUltima } from '../models/PanierUltima';
import * as signalR from '@aspnet/signalr';

@Injectable({
  providedIn: 'root'
})
export class UltimaRService {

  public data: IPanierUltima[];

  private hubConnection: signalR.HubConnection;

  public startConnection() {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:5001/ultima')
      .build();

    this.hubConnection
      .onclose(async () => await this.start());

    this.hubConnection
      .start()
      .then(() => console.log('Connection started'))
      .catch(err => console.log('Une erreur est survenu avec la connexion : ' + err));

  }

  async start() {
    try {
        await this.hubConnection.start();
        console.log("connected");
    } catch (err) {
        console.log(err);
        setTimeout(() => this.start(), 3000);
    }
};

  public ecouterPanierUltimaErreur() {
    this.hubConnection.on('panier-ultima-erreur', (data) => {
      this.data = data;
      console.log(data);
    });
  }
}
