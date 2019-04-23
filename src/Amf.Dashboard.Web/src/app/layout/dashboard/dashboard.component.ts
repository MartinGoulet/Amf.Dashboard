import { Component, OnInit } from '@angular/core';
import { routerTransition } from '../../router.animations';
import { UltimaRService } from 'src/app/shared/services/ultima-r.service';
import { IPanierUltima } from 'src/app/shared/models/PanierUltima';

@Component({
    selector: 'app-dashboard',
    templateUrl: './dashboard.component.html',
    styleUrls: ['./dashboard.component.scss'],
    animations: [routerTransition()]
})
export class DashboardComponent implements OnInit {

    public data: IPanierUltima[] = [];

    constructor(public serviceUltima: UltimaRService) {

    }

    ngOnInit() {
        this.serviceUltima.data2.subscribe((data) => {
            this.data = data;
        });
        this.serviceUltima.startConnection();
        this.serviceUltima.ecouterPanierUltimaErreur();
    }

    public ObtenirCouleur() {
        switch (this.data.length) {
            case 0:
            case 1:
                return 'success';
            case 2:
            case 3:
                return 'warning';
            default:
                return 'danger';
        }
    }
}
