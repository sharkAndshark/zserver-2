import Map from 'ol/Map'
import TileLayer from 'ol/layer/Tile'
import View from 'ol/View'
import OSM from 'ol/source/OSM'
import { get as getProjection } from 'ol/proj'
import { getTopLeft, getWidth } from 'ol/extent'
import WMTS from 'ol/source/WMTS'
import WMTSTileGrid from 'ol/tilegrid/WMTS'
import proj4 from 'proj4'
import { register } from 'ol/proj/proj4'

const projection = getProjection('EPSG:4326')
const projectionExtent = projection.getExtent()
const size = getWidth(projectionExtent) / 256
const resolutions = new Array(22)
const matrixIds = new Array(22)
for (let z = 0; z < 22; ++z) {
  // generate resolutions and matrixIds arrays for this WMTS
  resolutions[z] = size / Math.pow(2, z)
  matrixIds[z] = z
}
debugger
let centerXY = [12.477070574987795, 41.85776175318455]

const map = new Map({
  target: 'map',
  layers: [
    new TileLayer({
      source: new WMTS({
        url: 'http://localhost:8200/wmts',
        layer: 'zserver:layer_group',
        matrixSet: 'EPSG:4326',
        format: 'image/webp',
        projection: projection,
        tileGrid: new WMTSTileGrid({
          origin: getTopLeft(projectionExtent),
          resolutions: resolutions,
          matrixIds: matrixIds,
        }),
        style: 'default',
        wrapX: true,
      }),
    }),
  ],
  view: new View({
    projection: projection,
    center: centerXY,
    zoom: 12,
  }),
})

function setProjection(code, name, proj4def, bbox) {
  if (code === null || name === null || proj4def === null || bbox === null) {
    return
  }

  var newProjCode = 'EPSG:' + code
  proj4.defs(newProjCode, proj4def)
  register(proj4)

  var newProj = getProjection(newProjCode)

  var worldExtent = [bbox[1], bbox[2], bbox[3], bbox[0]]
  newProj.setWorldExtent(worldExtent)
  // approximate calculation of projection extent,
  // checking if the world extent crosses the dateline
  if (bbox[1] > bbox[3]) {
    worldExtent = [bbox[1], bbox[2], bbox[3] + 360, bbox[0]]
  }

  // var extent = applyTransform(worldExtent, fromLonLat, undefined, 8);

  newProj.setExtent(worldExtent)
}
