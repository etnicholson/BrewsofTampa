import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { connectableObservableDescriptor } from 'rxjs/internal/observable/ConnectableObservable';
import { faBeer } from '@fortawesome/free-solid-svg-icons';
import { environment } from 'src/environments/environment';
import { Brewery } from '../_models/brewery';


@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css']
})
export class MapComponent implements OnInit {


  lat = 27.965853;
  lng = -82.800103;
  breweries: Brewery[];
  faBeer = faBeer;
  icon;

  baseUrl = environment.apiUrl + 'brewery/list/';
  uploadFolder = environment.uploadFolder;
  constructor(private http: HttpClient) { }

  ngOnInit() {
     this.icon = {
      url: 'http://45.79.206.206/assets/beer.svg',
      scaledSize: {
        height: 30,
        width: 20
      }
    };

    this.http.get(this.baseUrl)
    .subscribe((res: any ) => {
      this.breweries = res;
      console.log(this.breweries);
  });


  }



}
